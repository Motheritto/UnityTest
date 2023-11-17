using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Prefab1;
    public GameObject Prefab2;

    // ��������� ���������� ������� � ������� �������� ��������� 2
    int[,] GenerateArray(int width, int height)
    {
        int[,] array = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0 || j == 0 || i == width - 1 || j == height - 1)
                {
                    array[i, j] = 2;
                }
            }
        }
        return array;
    }

    // ��������� ������� �� ��������� 1 � 2 � ������������ � � ��������
    int[,] GenerateMatrix(int matrixSize)
    {
        int[,] matrix = new int[matrixSize, matrixSize];
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                if (i == 0 || j == 0 || i == matrixSize - 1 || j == matrixSize - 1)
                {
                    matrix[i, j] = 2;
                }
                else
                {
                    matrix[i, j] = 1;
                }
            }
        }
        return matrix;
    }

    // �������� ������� �� ��������� 1 � 2 � ��������� ��������
    void AddMatrixToArray(ref int[,] array, int[,] matrix, int posX, int posY)
    {
        int matrixSize = matrix.GetLength(0);
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                array[posX + i, posY + j] += matrix[i, j] - 1;
            }
        }
    }

    // ��������, �������� �� ��������� ������ ����� ���������� ���������
    bool IsArrayFull(int[,] array, int matrixSize)
    {
        for (int i = 0; i < array.GetLength(0) - matrixSize; i++)
        {
            for (int j = 0; j < array.GetLength(1) - matrixSize; j++)
            {
                bool isPossibleMatrix = true;
                for (int x = 0; x < matrixSize; x++)
                {
                    for (int y = 0; y < matrixSize; y++)
                    {
                        if (array[i + x, j + y] != 1 && array[i + x, j + y] != 2)
                        {
                            isPossibleMatrix = false;
                            break;
                        }
                    }
                    if (!isPossibleMatrix)
                    {
                        break;
                    }
                }
                if (isPossibleMatrix)
                {
                    return false;
                }
            }
        }

        return true;
    }

    void Start()
    {
        // ������� �������
        int width = 30;
        int height = 30;
        int matrixMinSize = 4;
        int matrixMaxSize = 6;

        // �������� ���������� ������� � ���������� ��� 2 �� ������� �������
        int[,] array = GenerateArray(width, height);

        // ��������� ������� � � ���������� � ���������� �������, ����������, ���� ��������� ������ �� ���������� ����� ���������� ���������
        while (!IsArrayFull(array, matrixMaxSize))
        {
            int matrixSize = Random.Range(matrixMinSize, matrixMaxSize + 1);
            int[,] matrix = GenerateMatrix(matrixSize);
            for (int i = 0; i < width - matrixSize; i++)
            {
                for (int j = 0; j < height - matrixSize; j++)
                {
                    bool isPossibleMatrix = true;
                    for (int x = 0; x < matrixSize; x++)
                    {
                        for (int y = 0; y < matrixSize; y++)
                        {
                            if (array[i + x, j + y] != 1 && array[i + x, j + y] != 2)
                            {
                                isPossibleMatrix = false;
                                break;
                            }
                        }
                        if (!isPossibleMatrix)
                        {
                            break;
                        }
                    }
                    if (isPossibleMatrix)
                    {
                        AddMatrixToArray(ref array, matrix, i, j);
                    }
                }
            }
        }

        // ��������� �������� �� ������ ���������� �������
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (array[i, j] == 1)
                {
                    Instantiate(Prefab1, new Vector3(i, 0, j), Quaternion.identity);
                }
                else if (array[i, j] == 2)
                {
                    Instantiate(Prefab2, new Vector3(i, 0, j), Quaternion.identity);
                }
            }
        }
    }
}
