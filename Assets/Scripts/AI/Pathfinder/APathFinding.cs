using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cysharp.Threading.Tasks;
using System;

namespace TDShooter.AI.PathFinder
{
    public class APathFinding : MonoBehaviour
    {
        /// <summary>
        /// ���� �� ��������� ����� �� ��������
        /// </summary>
        public List<Tile> _pathPoint = new();
        public Tile _startPointTile;
        public Tile _currentPointTile;
        public Tile _endPointTile;
        public EndPoint _endPoint;
        public CreateTileField _createTileField;//zenject ���������� �� �� �������� ������� � ��������. ������� ������� ����� �����������
        private Position_Marker _marker;

        public Dictionary<Tile, float> _open_ListTile = new(); //�������� ������ ������
        public List<Tile> _closed_ListTile = new(); //�������� ������ ������    

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
        private void Start()
        {
            _marker = GetComponentInChildren<Position_Marker>();
        }

/*        private void Update()
        {
                        if (Input.GetKeyDown(KeyCode.Space))
                            PathFinding();
        }*/

        public void PathFinding()
        {


            //����� ������� ��������� ���� ������
            foreach (Tile tile in _createTileField._tileExamples)
            {
                if (tile.TileState != enums.TileState.Obstacle)// || tile.TileState != enums.TileState.Unit)
                {
                    tile.mesh.material.color = Color.white;
                    tile.SetTileState(enums.TileState.None);
                    tile._previosPoint = null;
                }
            }

            //������� ��� ������
            _open_ListTile.Clear();
            _closed_ListTile.Clear();

            //��������� ������� ������ ���������
            _currentPointTile = _startPointTile;
            //��������� � �������� ������ ��� ������ ���������� �������������
            foreach (Tile tile in _createTileField._tileExamples)
            {
                if (tile.TileState == enums.TileState.Obstacle)
                {
                    _closed_ListTile.Add(tile);
                }
            }

            foreach (Tile tile in _currentPointTile._tileNear)
            {
                if (tile.TileState != enums.TileState.ClosedList)
                {
                    _open_ListTile.Add(tile, 0f);
                    tile.SetTileState(enums.TileState.OpenedList);
                }
            }

            //��������� � �������� ������ ��������� �����         
            _closed_ListTile.Add(_currentPointTile);

            var result = StartFindPath();
        }

        public async UniTaskVoid StartFindPath()
        {
            while (_currentPointTile != _endPointTile)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
                FindPath();
                await UniTask.Yield();

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

            if (_currentPointTile.TileState != enums.TileState.Obstacle)
                _currentPointTile.mesh.material.color = Color.gray;

            _currentPointTile.SetTileState(enums.TileState.ClosedList);


            _currentPointTile = sortedList.First().Key; //�������� ����� ������ �� ������� ������ � ��������� ���������� ����
            if (_currentPointTile == _endPointTile)
            {
                _pathPoint.Clear();
                //_endPointTile.RestorePath(_pathPoint);

                var MYPOINT = _endPointTile;
                while (MYPOINT._previosPoint != null)
                {
                    _pathPoint.Add(MYPOINT);
                    MYPOINT.mesh.material.color = Color.blue;
                    MYPOINT.SetTileState(enums.TileState.Way);
                    MYPOINT = MYPOINT._previosPoint;
                }

                _marker.TakeNewTarget(_pathPoint[^1].transform);

                //StopAllCoroutines();

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