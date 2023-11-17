using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public GameObject prefab11;
    public GameObject prefab22;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }

    void Start()
    {
        // Генерация начального двумерного массива  
        int[,] initialArray = new int[30, 30];

        for (int i = 0; i < initialArray.GetLength(0); i++)
        {
            for (int j = 0; j < initialArray.GetLength(1); j++)
            {
                // Установка границ
                if (i == 0 || i == initialArray.GetLength(0) - 1 || j == 0 || j == initialArray.GetLength(1) - 1)
                {
                    initialArray[i, j] = 2;
                }
                else
                {
                    initialArray[i, j] = 0;
                }
            }
        }

        // Генерация матриц внутри начального массива 
        while (HasEmptyCells(initialArray))
        {
            int rows = Random.Range(4, 7);
            int cols = Random.Range(4, 7);

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Установка границ
                    if (i == 0 || i == matrix.GetLength(0) - 1 || j == 0 || j == matrix.GetLength(1) - 1)
                    {
                        matrix[i, j] = 2;
                    }
                    else
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            // Прибавление матрицы к начальному массиву 
            int startX = Random.Range(1, initialArray.GetLength(0) - rows - 1);
            int startY = Random.Range(1, initialArray.GetLength(1) - cols - 1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    initialArray[startX + i, startY + j] += matrix[i, j];
                }
            }
        }

        // Размещение префабов на местах соответствующих значениям в массиве  
        for (int i = 0; i < initialArray.GetLength(0); i++)
        {
            for (int j = 0; j < initialArray.GetLength(1); j++)
            {
                if (initialArray[i, j] == 1)
                {
                    Instantiate(prefab11, new Vector3(i, j, 0), Quaternion.identity);
                }
                else if (initialArray[i, j] == 2)
                {
                    Instantiate(prefab22, new Vector3(i, j, 0), Quaternion.identity);
                }
            }
        }

        // Проверка наличия оставшихся пустых клеток в массиве  
        bool HasEmptyCells(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
