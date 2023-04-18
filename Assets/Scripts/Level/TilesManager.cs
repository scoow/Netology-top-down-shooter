using TDShooter.enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TDShooter.Level
{
    public class TilesManager : MonoBehaviour
    {
        [SerializeField]
        private int _gridSize = 3;
        public Tile_Marker[,] tiles;
        private Tile_Marker[] tempArray;
        private void Start()
        {
            tiles = new Tile_Marker[_gridSize, _gridSize];
            tempArray = new Tile_Marker[_gridSize];
            List<Tile_Marker> list = new();
            list = FindObjectsOfType<Tile_Marker>().ToList();
            list.Sort((x, y) => x.number.CompareTo(y.number));
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    tiles[i, j] = list[i * _gridSize + j];
                    tiles[i, j].Callback += MoveRow;
                }
            }
        }
        private void MoveRow(Tile_Marker number)
        {
            if (number == tiles[0, 1])
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

            switch (direction)
            {
                case Direction.Up:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        Vector3 newPos = tiles[_gridSize-1, i].transform.position;
                        newPos.z += 30;
                        tiles[_gridSize-1, i].transform.position = newPos;

                        tempArray[i] = tiles[_gridSize - 1, i];

                    }
                    RebindArray(Direction.Up);
                    break;
                case Direction.Down:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        Vector3 newPos = tiles[0, i].transform.position;
                        newPos.z -= 30;
                        tiles[0, i].transform.position = newPos;

                        tempArray[i] = tiles[0, i];
                    }
                    RebindArray(Direction.Down);
                    break;
                case Direction.Left:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        Vector3 newPos = tiles[i, _gridSize - 1].transform.position;
                        newPos.x -= 30;
                        tiles[i, _gridSize - 1].transform.position = newPos;

                        tempArray[i] = tiles[i, _gridSize - 1];
                    }
                    RebindArray(Direction.Left);
                    break;
                case Direction.Right:
                    for (int i = 0; i < _gridSize; i++)
                    {
                        Vector3 newPos = tiles[i, 0].transform.position;
                        newPos.x += 30;
                        tiles[i, 0].transform.position = newPos;

                        tempArray[i] = tiles[i, 0];
                    }
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
    }
}