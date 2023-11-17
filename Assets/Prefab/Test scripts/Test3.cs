using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    public GameObject Prefab111;
    public GameObject Prefab222;
    // Start is called before the first frame update
    void Start()
    {
        // —оздайте двумерный массив размером 32 на 32 с внешними €чейками равными 2
        int[,] grid = new int[32, 32];
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                if (i < 2 || j < 2 || i > 29 || j > 29)
                {
                    grid[i, j] = 2;
                }
                else
                {
                    grid[i, j] = 0;
                }
            }
        }

        // —оздайте генератор матриц размером от 4 на 4 до 6 на 6
        for (int size = 4; size <= 6; size++)
        {
            for (int i = 2; i <= 27 - size + 2; i++)
            {
                for (int j = 2; j <= 27 - size + 2; j++)
                {
                    bool allOnes = true;
                    for (int r = i; r < i + size; r++)
                    {
                        for (int c = j; c < j + size; c++)
                        {
                            if (grid[r, c] != 1)
                            {
                                allOnes = false;
                                break;
                            }
                        }
                        if (!allOnes) break;
                    }
                    if (allOnes) continue;

                    // «аполнение матрицы со значени€ми €чеек 1 и 2
                    for (int r = i - 1; r < i + size + 1; r++)
                    {
                        for (int c = j - 1; c < j + size + 1; c++)
                        {
                            if (r < 0 || c < 0 || r >= 32 || c >= 32 || grid[r, c] != 0)
                            {
                                continue;
                            }
                            if (r == i - 1 || c == j - 1 || r == i + size || c == j + size)
                            {
                                grid[r, c] = 2;
                            }
                            else
                            {
                                grid[r, c] = 1;
                            }
                        }
                    }
                }
            }
        }

        // –азмещение префабов на основе значений €чеек
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                if (grid[i, j] == 1)
                {
                    Instantiate(Prefab111, new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (grid[i, j] == 2)
                {
                    Instantiate(Prefab222, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
