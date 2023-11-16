using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Reborn : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public int RoomCount;
    private int Repeater = 0;

    public GameObject Void0;
    public GameObject Border1;
    public GameObject Corridor2;
    public GameObject Wall3;
    public GameObject Floor4;
    public GameObject Door5;
    public GameObject PlayerSpawn6;
    public GameObject EnemySpawn7;
    public GameObject PlayerRoom8;
    public GameObject BossWall9;
    public GameObject BossFloor10;
    public GameObject BossSpawn11;
    public GameObject Objects12;
    public GameObject Player6;
    public GameObject Boss11;
    public GameObject Enemy7;
    public GameObject Torch13;
    public GameObject Lamp14;
    public GameObject LadderEnter15;
    public GameObject LadderExit16;
    public GameObject Partition17;

    void Start()
    {
        int[,,] Level = new int[x * 10 - 5, y, z * 10 - 5]; // Создание двумерного массива уровня
        CreateCarcass(Level);
        CreateSpecialRoom(Level, "Boss", 2, 4, 5, 3, 10);
        for (int k = 0; k < Level.GetLength(1) - 1; k++)
        {
            CreateLadder(Level, 3, 15, k);
        }
        CreateSpecialRoom(Level, "Spawn", 1, 2, 2, 3, 8);
        for (int i = 0; i < RoomCount; RoomCount--)
        {
            CreateRoom(Level, 3, 4);
        }
        CreateSpecialObjects(Level, 8, 100, 6, 1); //Игрок
        CreateSpecialObjects(Level, 4, 50, 7, 0); //Враг

        CreateObjects(Level);
        ShowLevel(Level);
    }

        //Генерируем Основную матрицу уровня, заполняем ее границу объектами границы = 1 (Border1) и заполняем внутренности пустотой = 0 (Void0)
        public int[,,] CreateCarcass(int[,,] Level)
    {
        for (int i = 0; i < Level.GetLength(0); i++)
        {
            for (int k = 0; k < Level.GetLength(1); k++)
            {
                for (int j = 0; j < Level.GetLength(2); j++)
                {
                    if (Level[i, k, j] == 0 && (i <= 3 || j <= 3 || i >= Level.GetLength(0) - 4 || j >= Level.GetLength(2) - 4))
                    {
                        Level[i, k, j] = 1;
                    }
                }
            }
        }
        return Level;
    }

    //=================================================================================================================================================================================================================================================================================

    //Генерирует комнату и заполняет ее стеной = 3(Wall3)
    public void CreateRoom(int[,,] Level, int Wall, int Floor)
    {
        Debug.Log("Осталось " + RoomCount + " комнат.");
        int RandX = Random.Range(1, 4); Debug.Log(RandX);
        int RandZ = Random.Range(1, 4); Debug.Log(RandZ);

        int RoomX = RandX * 7 + (RandX - 1) * 3;
        int RoomZ = RandZ * 7 + (RandZ - 1) * 3;
        for (int i = 4; i < Level.GetLength(0) - 5; i++)
        {
            for (int k = 0; k < Level.GetLength(1); k++)
            {
                for (int j = 4; j < Level.GetLength(2) - 5; j++)
                {
                    if (Level[i, k, j] == 0 && RoomX + i < Level.GetLength(0) - 3 && RoomZ + j < Level.GetLength(2) - 3)
                    {
                        for (int ii = 0; ii < i + RoomX; ii++)
                        {
                            for (int jj = 0; jj < j + RoomZ; jj++)
                            {
                                if (Level[ii, k, jj] == 0 && (ii > i - 1 && jj > j - 1))
                                {
                                    Level[ii, k, jj] = Wall;
                                }
                            }
                        }
                        CreateCorridors(Level, RoomX, RoomZ, i, k, j, Wall, Floor);
                        return;
                    }
                }
            }
        }
    }

    //Генерируем коридоры вокруг созданной комнаты = 2 (Corridors2)
    public void CreateCorridors(int[,,] Level, int RoomX, int RoomZ, int i, int k, int j, int Wall, int Floor)
    {
        int Rand = Random.Range(0, 2);

        for (int ii = i - 3; ii < i + RoomX + 3; ii++)
        {
            for (int kk = k; kk < Level.GetLength(1); kk++)
            {
                for (int jj = j - 3; jj < j + RoomZ + 3; jj++)
                {
                    if (Level[ii, k, jj] <= Rand) { Level[ii, k, jj] = 2; }
                }
            }
        }
        CreateFloor(Level, RoomX, RoomZ, i, k, j, Wall, Floor);
    }

    //Заменяет внутренние стены = 3(Wall3) комнаты полом = 4(Floor4)
    public void CreateFloor(int[,,] Level, int RoomX, int RoomZ, int i, int k, int j, int Wall, int Floor)
    {
        int FloorCounter = 0;
        for (int ii = 1; ii < i + RoomX - 1; ii++)
        {
            for (int kk = k; kk < Level.GetLength(1); kk++)
            {
                for (int jj = 1; jj < j + RoomZ - 1; jj++)
                {
                    if (Level[ii, k, jj] == Wall && (Level[ii + 1, k, jj] > 2 && Level[ii, k, jj + 1] > 2 && Level[ii + 1, k, jj + 1] > 2 && Level[ii - 1, k, jj] > 2 && Level[ii, k, jj - 1] > 2 && Level[ii - 1, k, jj - 1] > 2 && Level[ii + 1, k, jj - 1] > 2 && Level[ii - 1, k, jj + 1] > 2))
                    {
                        Level[ii, k, jj] = Floor; //Если у клетки по соседству нет ни коридора, ни границы уровня, то ставит в это место пол для комнаты
                        FloorCounter++;
                    }
                }
            }
        }
        if (FloorCounter > 0 && FloorCounter <=25) { CreateDoor(Level, RoomX, RoomZ, i, k, j, Wall, Floor); }
        else { CreatePartition(Level, RoomX, RoomZ, i, k, j, Wall, Floor); }
    }

    public void CreatePartition(int[,,] Level, int RoomX, int RoomZ, int i, int k, int j, int Wall, int Floor)
    {

        for (int ii = i; ii < i + RoomX; ii++)
        {
            for (int kk = k; kk < Level.GetLength(1); kk++)
            {
                for (int jj = j; jj < j + RoomZ; jj++)
                {
                    if (Level[ii, k, jj] == 4 && ((ii % 10 == 4 || ii % 10 == 0) || (jj % 10 == 4 || jj % 10 == 0)))
                    {
                        Level[ii, k, jj] = 17;
                    }
                }
            }
        }
        CreateDoor(Level, RoomX, RoomZ, i, k, j, Wall, Floor);
    }

    //Метод создающий дверь = 5(Door5) для комнаты, вместо стены = 3(Wall3)
    public int[,,] CreateDoor(int[,,] Level, int RoomX, int RoomZ, int i, int k, int j, int Wall, int Floor)
    {
        int DoorCounter = 0;

        for (int ii = i; ii < i + RoomX; ii++)
        {
            for (int kk = k; kk < Level.GetLength(1); kk++)
            {
                for (int jj = j; jj < j + RoomZ; jj++)
                {
                    if (Level[ii, k, jj] == 2) { break; } // Чинит ФИЧУ которая с шансом в примерно 1/100 оставляет кривую комнату без двери, которая создается у комнаты рядом (справа) из-за чего с шансом примерно в 1/10 000, игрок мог появиться в комнате без выхода
                    if (Level[ii, k, jj] == Wall && DoorCounter == 0 && Random.Range(1, 51) == 1 && ((Level[ii - 1, k, jj] == 2 && Level[ii + 1, k, jj] == Floor) || (Level[ii + 1, k, jj] == 2 && Level[ii - 1, k, jj] == Floor) || (Level[ii, k, jj + 1] == 2 && Level[ii, k, jj - 1] == Floor) || (Level[ii, k, jj - 1] == 2 && Level[ii, k, jj + 1] == Floor)))
                    {
                        Level[ii, k, jj] = 5; //Если клетка является стеной у которой либо слева и справа, либо сверху и снизу находятся коридор или пол, то с шаносм указанным в Random.Rande ставит в эту ячейку дверь
                        DoorCounter++;
                        break;
                    }
                }
            }
        }
        if (DoorCounter == 0) { CreateDoor(Level, RoomX, RoomZ, i, k, j, Wall, Floor); } //Вызывает метод повторно до тех пор, пока у комнаты не сгенерируется дверь
        return (Level);
    }


    //=================================================================================================================================================================================================================================================================================


    //Заменяем цифровые значения игровыми объектами
    public void ShowLevel(int[,,] Level)
    {
        for (int i = 0; i < Level.GetLength(0); i++)
        {
            for (int k = 0; k < Level.GetLength(1); k++) //Проходя весь цифровой двумерный массив, по его значениям создает физический уровень
            {
                for (int j = 0; j < Level.GetLength(2); j++) //Проходя весь цифровой двумерный массив, по его значениям создает физический уровень
                {
                        if (Level[i, k, j] == 0) { Instantiate(Void0, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 1) { Instantiate(Border1, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 2) { Instantiate(Corridor2, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 3) { Instantiate(Wall3, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 4) { Instantiate(Floor4, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 5) { Instantiate(Door5, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 6) { Instantiate(PlayerSpawn6, new Vector3(i, k * 10, j), Quaternion.identity); Instantiate(Player6, new Vector3(i, k * 10 + 0.5f, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 7) { Instantiate(EnemySpawn7, new Vector3(i, k * 10, j), Quaternion.identity); Instantiate(Enemy7, new Vector3(i, k * 10 + 0.5f, j), Quaternion.identity);}
                        else if (Level[i, k, j] == 8) { Instantiate(PlayerRoom8, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 9) { Instantiate(BossWall9, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 10) { Instantiate(BossFloor10, new Vector3(i, k * 10, j), Quaternion.identity); }
                        // else if (Level[i, j] == 11) { Instantiate(BossSpawn11, new Vector3(i, 0, j), Quaternion.identity); Instantiate(Boss11, new Vector3(i, 1, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 12) { Instantiate(Objects12, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 15) { Instantiate(LadderEnter15, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 16) { Instantiate(LadderExit16, new Vector3(i, k * 10, j), Quaternion.identity); }
                        else if (Level[i, k, j] == 17) { Instantiate(Partition17, new Vector3(i, k * 10, j), Quaternion.identity); }
                }
            }
        }
    }


        //=================================================================================================================================================================================================================================================================================


        //Создает специальные комнаты (Комната игрока, комната босса)
        public void CreateSpecialRoom(int[,,] Carcass, string Name, int MinSize, int MaxSize, int SizePoint, int Wall, int Floor)
    {
        Debug.Log("Комната " + Name);
        int RandX = Random.Range(MinSize, MaxSize); Debug.Log(RandX);
        int RandZ = SizePoint - RandX; Debug.Log(RandZ);

        int PosX = Random.Range(1, x - RandX + 1) * 10 - 6; Debug.Log("X " + PosX);
        int PosZ = Random.Range(1, z - RandZ + 1) * 10 - 6; Debug.Log("Z " + PosZ);
        int PosY = Random.Range(0, y); Debug.Log("Этаж " + PosY);

        int RoomX = RandX * 7 + (RandX - 1) * 3;
        int RoomZ = RandZ * 7 + (RandZ - 1) * 3;

        int Limiter = 0;

        for (int i = PosX; i < PosX + RoomX; i++)
        {
            for (int k = PosY; k == PosY; k++)
            {
                for (int j = PosZ; j < PosZ + RoomZ; j++)
                {
                    if (Carcass[i, k, j] == 0) { Carcass[i, k, j] = Wall; Limiter++; }
                    else if (Carcass[i, k, j] != 0 && Repeater < 50) { Repeater++; CreateSpecialRoom(Carcass, Name, MinSize, MaxSize, SizePoint, Wall, Floor); return; }
                }
            }
        }
        CreateCorridors(Carcass, RoomX, RoomZ, PosX, PosY, PosZ, Wall, Floor);
    }


    //=================================================================================================================================================================================================================================================================================


    //Создает комнату лестницу для соединения этажей
    public void CreateLadder(int[,,] Carcass, int Wall, int Floor, int Height)
    {
        int PosX = Random.Range(1, x) * 10 - 6; Debug.Log("X " + PosX);
        int PosZ = Random.Range(1, z) * 10 - 6; Debug.Log("Z " + PosZ);
        Debug.Log("Этаж " + Height);

        int RoomX = 7;
        int RoomZ = 7;

        for (int i = PosX; i < PosX + RoomX; i++)
        {
            for (int k = Height; k == Height; k++)
            {
                for (int j = PosZ; j < PosZ + RoomZ; j++)
                {
                    if (Carcass[i, k, j] == 0 && Carcass[i, k + 1, j] == 0) { Carcass[i, k, j] = Wall; Carcass[i, k + 1, j] = Wall; }

                    else if ((Carcass[i, k, j] != 0 || Carcass[i, k + 1, j] != 0) && Repeater < 50) { Repeater++; CreateLadder(Carcass, Wall, Floor, Height); return; }
                }
            }
        }
        CreateCorridors(Carcass, RoomX, RoomZ, PosX, Height, PosZ, Wall, Floor);
        CreateCorridors(Carcass, RoomX, RoomZ, PosX, Height + 1, PosZ, Wall, Floor + 1);
    }


    //=================================================================================================================================================================================================================================================================================


    //Создает объекты для взаимодействия
    public int[,,] CreateObjects(int[,,] Level)
    {
        int RandomObjects
        = 1;
        for (int i = 1; i < Level.GetLength(0) - 1; i++)
        {
            for (int k = 0; k < Level.GetLength(1); k++)
            {
                for (int j = 1; j < Level.GetLength(2) - 1; j++)
                {
                    if (Level[i, k, j] == 4 && RandomObjects == Random.Range(1, 11) && ((Level[i - 1, k, j] == 3 && Level[i, k, j - 1] == 3) || (Level[i + 1, k, j] == 3 && Level[i, k, j - 1] == 3) || (Level[i - 1, k, j] == 3 && Level[i, k, j - 1] == 3) || (Level[i - 1, k, j] == 3 && Level[i, k, j + 1] == 3)))
                    {
                        Level[i, k, j] = 12;
                    }
                }
            }
        }
        return (Level);
    }

    public int[,,] CreateSpecialObjects(int[,,] Level, int Floor, int Rare, int Object, int Limiter)
    {
        int LimCounter = 0;

        for (int i = 1; i < Level.GetLength(0) - 1; i++)
        {
            for (int k = 0; k < Level.GetLength(1); k++)
            {
                for (int j = 1; j < Level.GetLength(2) - 1; j++)
                {
                    if (Level[i, k, j] == Floor && Random.Range(1, Rare + 1) == 1)
                    {
                        Level[i, k, j] = Object;
                        LimCounter++;
                        if (Limiter == LimCounter) { return (Level); }
                    }
                }
            }
        }
        if (LimCounter == 0) { CreateSpecialObjects(Level, Floor, Rare, Object, Limiter); }
        return (Level);
    }




}