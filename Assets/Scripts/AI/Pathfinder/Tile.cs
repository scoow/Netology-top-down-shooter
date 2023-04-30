using System.Collections.Generic;
using TDShooter.enums;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.AI.PathFinder
{
    public class Tile : MonoBehaviour
    {
        public MeshRenderer mesh;
        public Text _id;
        public Text _distanceToNear;
        public Text _distanceToEndTile;
        public Text _weightTile;
        /// <summary>
        /// ID �����
        /// </summary>
        public int _iD;
        /// <summary>
        /// ������ �������� �����
        /// </summary>
        public List<Tile> _tileNear;
        /// <summary>
        /// T���� �� ������� ������ � �������
        /// </summary>
        public Tile _previosPoint;
        private TileState _tileState = TileState.None;
        public TileState TileState => _tileState;

        public void SetTileState(TileState state)
        {
            _tileState = state;
        }

/*        public void RestorePath(List<Tile> path)
        {
            path.Add(this);
            Debug.Log("RestorePath ����������");
            if (_previosPoint != null)
            {
                _previosPoint.RestorePath(path);
                _previosPoint.mesh.material.color = Color.green;
            }
        }*/
    }
}