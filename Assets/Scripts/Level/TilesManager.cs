using TDShooter.enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TDShooter.Level
{
    public class TilesManager : MonoBehaviour
    {
        [SerializeField]
        private int _gridSize = 3;//размер сетки
        public Tile_Marker[,] tiles;//массив ссылок на тайлы
        private Tile_Marker[] tempArray;//временный массив для 

        private LeftBottomCorner_Marker _leftBottomCorner_Marker;

        [SerializeField]
        private int _offsetSize;
        private int _cornerOffsetSize = 50;//сделать красиво
        private void Start()
        {
            _leftBottomCorner_Marker= GetComponentInChildren<LeftBottomCorner_Marker>();
            ///инициализируем массивы
            tiles = new Tile_Marker[_gridSize, _gridSize];
            tempArray = new Tile_Marker[_gridSize];
            //находим компоненты Tile_Marker на сцене и упорядочиваем их по номеру
            List<Tile_Marker> list = new();
            list = FindObjectsOfType<Tile_Marker>().ToList();
            list.Sort((x, y) => x.Number.CompareTo(y.Number));
            //затем добавляем их в массив
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    tiles[i, j] = list[i * _gridSize + j];
                    tiles[i, j].Callback += MoveRow;
                }
            }

           // _cornerOffsetSize = (int)list[0].transform.sc;
        }
        public bool IsInMiddle(Tile_Marker tile)
        {
            return (tile == tiles[1, 1]);
        }

        private void MoveRow(Tile_Marker number)
        {
            if (number == tiles[0, 1])//добавить условие
            {
                Debug.Log("up");
                ReBuild(Direction.Up);
            }
            if (number == tiles[1, 0])
            {
                Debug.Log("left");
                ReBuild(Direction.Left);
            }
            if (number == tiles[1, 2])
            {
                Debug.Log("right");
                ReBuild(Direction.Right);
            }
            if (number == tiles[2, 1])
            {
                Debug.Log("down");
                ReBuild(Direction.Down);
            }
        }
        private void ReBuild(Direction direction)
        {
            Vector3 newPos;
            switch (direction)
            {
                case Direction.Up:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        newPos = tiles[_gridSize-1, i].transform.position;
                        newPos.z += _offsetSize;
                        
                        tiles[_gridSize-1, i].transform.position = newPos;

                        tempArray[i] = tiles[_gridSize - 1, i];
                    }
                    newPos = _leftBottomCorner_Marker.transform.position;//сделать короче
                    newPos.z += _cornerOffsetSize;
                    _leftBottomCorner_Marker.transform.position = newPos;
                    RebindArray(Direction.Up);
                    break;
                case Direction.Down:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        newPos = tiles[0, i].transform.position;
                        newPos.z -= _offsetSize;
                        tiles[0, i].transform.position = newPos;

                        tempArray[i] = tiles[0, i];
                    }
                    newPos = _leftBottomCorner_Marker.transform.position;//сделать короче
                    newPos.z -= _cornerOffsetSize;
                    _leftBottomCorner_Marker.transform.position = newPos;
                    RebindArray(Direction.Down);
                    break;
                case Direction.Left:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        newPos = tiles[i, _gridSize - 1].transform.position;
                        newPos.x -= _offsetSize;
                        tiles[i, _gridSize - 1].transform.position = newPos;

                        tempArray[i] = tiles[i, _gridSize - 1];
                    }
                    newPos = _leftBottomCorner_Marker.transform.position;//сделать короче
                    newPos.x -= _cornerOffsetSize;
                    _leftBottomCorner_Marker.transform.position = newPos;
                    RebindArray(Direction.Left);
                    break;
                case Direction.Right:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        newPos = tiles[i, 0].transform.position;
                        newPos.x += _offsetSize;
                        tiles[i, 0].transform.position = newPos;

                        tempArray[i] = tiles[i, 0];
                    }
                    newPos = _leftBottomCorner_Marker.transform.position;//сделать короче
                    newPos.x += _cornerOffsetSize;
                    _leftBottomCorner_Marker.transform.position = newPos;
                    RebindArray(Direction.Right);
                    break;
                default:
                    break;
            }
        }

        private void RebindArray(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int i = _gridSize - 1; i > 0; i--)
                    {
                        for (int j = 0; j < _gridSize; j++)
                        {
                            tiles[i, j] = tiles[i - 1, j];
                        }
                    }
                    for (int j = 0; j < _gridSize; j++)
                    {
                        tiles[0, j] = tempArray[j];
                    }
                    break;
                case Direction.Down:
                    for (int i = 0; i < _gridSize - 1; i++)
                    {
                        for (int j = 0; j < _gridSize; j++)
                        {
                            tiles[i, j] = tiles[i + 1, j];
                        }
                    }
                    for (int j = 0; j < _gridSize; j++)
                    {
                        tiles[_gridSize - 1, j] = tempArray[j];
                    }
                    break;
                case Direction.Left:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        for (int j = _gridSize-1; j > 0; j--)
                        {
                            tiles[i, j] = tiles[i, j - 1];
                        }
                    }
                    for (int j = 0; j < _gridSize; j++)
                    {
                        tiles[j, 0] = tempArray[j];
                    }
                    break;
                case Direction.Right:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        for (int j = 0; j < _gridSize - 1; j++)

                        {
                            tiles[i, j] = tiles[i, j + 1];
                        }
                    }
                    for (int j = 0; j < _gridSize; j++)
                    {
                        tiles[j, _gridSize - 1] = tempArray[j];
                    }
                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// отписываемся от реакции на движение
        /// </summary>
        private void OnDisable()
        {
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    tiles[i, j].Callback -= MoveRow;
                }
            }
        }
    }
}