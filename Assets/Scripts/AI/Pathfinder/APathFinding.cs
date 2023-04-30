using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

namespace TDShooter.AI.PathFinder
{
    public class APathFinding : MonoBehaviour
    {
        /// <summary>
        /// ���� �� ��������� ����� �� ��������
        /// </summary>
        public List<Tile> _pathPoint = new List<Tile>();
        public Tile _startPointTile;
        public Tile _currentPointTile;
        public Tile _endPointTile;
        public EndPoint _endPoint;
        public CreateTileField _createTileField;

        public Dictionary<Tile, float> _open_ListTile = new Dictionary<Tile, float>(); //�������� ������ ������
        public List<Tile> _closed_ListTile = new List<Tile>(); //�������� ������ ������    

        /// <summary>
        /// ������� ��������� ����� ���� �� ������-��������
        /// </summary>
        /// <returns></returns>
       public Transform ReturnNextPoint()
        {
            //return _pathPoint[_pathPoint.Count - 1].transform;
            return _pathPoint[0].transform;
        }

        private void OnEnable()
        {
            _endPoint = FindObjectOfType<EndPoint>();
            _endPoint.OnEndPoint += GetEndPointTile;

            _createTileField = FindObjectOfType<CreateTileField>();
        }

        private void GetEndPointTile(Tile tile)
        {
            _endPointTile = tile;
        }

        private void Update()
        {
/*            if (Input.GetKeyDown(KeyCode.Space))
                PathFinding();*/
        }

        public void PathFinding()
        {
            //������� ��� ������
            _open_ListTile.Clear();
            _closed_ListTile.Clear();
            //��������� ������� ������ ���������
            _currentPointTile = _startPointTile;
            //��������� � �������� ������ ��� ������ ���������� �������������
            foreach (Tile tile in _createTileField._tileExamples)
            {
                if (tile.mesh.material.color == Color.red)
                {
                    _closed_ListTile.Add(tile);
                    tile.mesh.material.color = Color.grey;
                }
            }

            foreach (Tile tile in _currentPointTile._tileNear)
            {
                if (tile.mesh.material.color != Color.red)
                {
                    _open_ListTile.Add(tile, 0f);
                }
            }

            //��������� � �������� ������ ��������� �����         
            _closed_ListTile.Add(_currentPointTile);

            StartCoroutine(TestCoroutine());

            //while (_currentPointTile != _endPointTile)
            //{
            //    FindPath();
            //}
        }

        IEnumerator TestCoroutine()
        {
            while (_currentPointTile != _endPointTile)
            {
                yield return new WaitForSeconds(0.5f);
                FindPath();
            }
        }

        public void FindPath()
        {
            //��������� �������� ����� � �������� ������
            foreach (Tile tile in _currentPointTile._tileNear)
            {
                //if (tile.mesh.material.color == Color.red) continue; //�������� �������� �� ID////////////////////////////////////
                if (_closed_ListTile.Contains(tile)) continue;
                if (_open_ListTile.ContainsKey(tile)) continue;

                _open_ListTile.Add(tile, CalculationWeightTile(_currentPointTile, tile, _endPointTile));
                tile._previosPoint = _currentPointTile; //���������� ��� ������ ������ ������ ������ �� ������� ������
            }

            var sortedList = _open_ListTile.OrderBy(p => p.Value); //��������� ��������� �������� �������� ������ �� �����������
           // Debug.Log(sortedList.First().Key);
            _open_ListTile.Remove(_currentPointTile);
            _closed_ListTile.Add(_currentPointTile); //��������� ����������(������������) ������ � �������� ������
            _currentPointTile.mesh.material.color = Color.grey;
            _currentPointTile = sortedList.First().Key; //�������� ����� ������ �� ������� ������ � ��������� ���������� ����
            if (_currentPointTile == _endPointTile)
            {
                _pathPoint.Clear();
                //_endPointTile.RestorePath(_pathPoint);

                var MYPOINT = _endPointTile;
                while (MYPOINT._previosPoint != null)
                {
                    _pathPoint.Add(MYPOINT);
                    MYPOINT.mesh.material.color = Color.green;
                    MYPOINT = MYPOINT._previosPoint;
                }

                StopAllCoroutines();

                foreach (Tile tile in _pathPoint)
                {
                    Debug.Log(tile._iD);
                }
            }
        }

        private float CalculationWeightTile(Tile curentTile, Tile nearTile, Tile endTile)
        {
            //���������� ��������� �� ������ ��������� (�������� ���������� ������)
            float distanceToNearTile = Mathf.Round(Mathf.Abs(curentTile.transform.position.x - nearTile.transform.position.x) + Mathf.Abs(curentTile.transform.position.z - nearTile.transform.position.z));
            float distanceToEndTile = Mathf.Round(Mathf.Abs(nearTile.transform.position.x - endTile.transform.position.x) + Mathf.Abs(nearTile.transform.position.z - endTile.transform.position.z));
            float weightTile = distanceToNearTile + distanceToEndTile;

            nearTile._distanceToNear.text = distanceToNearTile.ToString();
            nearTile._distanceToNear.color = Color.blue;
            nearTile._distanceToEndTile.text = distanceToEndTile.ToString();
            nearTile._distanceToEndTile.color = Color.green;
            nearTile._weightTile.text = weightTile.ToString();
            nearTile._weightTile.color = Color.red;

            return weightTile;
        }

        private void OnDisable()
        {
            _endPoint.OnEndPoint -= GetEndPointTile;
        }
    }
}