using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTiles : MonoBehaviour
{
    public GameObject Plane;
    public GameObject Plane2;
    private GameObject Plane3;
    public int xr;
    public int zr;
    private int RoomCounter = 2;

    void Start()
    {
        D();
        //LevelCreator();
        //Debug.Log(RoomCounter);

    }

    public void G()
    {
        for (int i = 0; i < RoomCounter; RoomCounter--)
        {
            D();
        }
    }

    public void D()
    {
        Debug.Log(RoomCounter);
    }

    public void LevelCreator()
    {
        int[,] Room = new int[xr, zr];
        for (int x = 0; x < xr; x++)
        {
            for (int z = 0; z < zr; z++)
            {
                Room[x, z] = (x % (xr - 1) != 0 && z % (zr - 1) != 0) ? 0 : 4;
                //Instantiate(Plane3 = Room[x, z] == 2 ? Plane2 : Plane, new Vector3(x, 0, z), Quaternion.identity);

                if (Room[x, z] == 4)
                {
                    Instantiate(Plane2, new Vector3(x, 0, z), Quaternion.identity);
                }
                if (Room[x, z] == 1)
                {
                    Instantiate(Plane, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
        CreateRoom(Room);
    }

    public void CreateRoom(int[,] Room)
    {
 
            int i = UnityEngine.Random.Range(4, 7);
            int j = UnityEngine.Random.Range(4, 7);
            int RoomCount = 0;
            Debug.Log(i);
            Debug.Log(j);

            for (int x = 1; x < xr - 1; x++)
            {
                for (int z = 1; z < zr - 1; z++)
                {
                    if (Room[x, z] == 0 && RoomCount < 1 && (x + i < xr - 2) && (z + j < zr - 2))
                    {
                        for (int RoomX = 0; RoomX < i; RoomX++)
                        {
                            for (int RoomZ = 0; RoomZ < j; RoomZ++)
                            {
                                if (Room[RoomX, RoomZ] == 0)
                                {
                                    Room[RoomX, RoomZ] = (RoomX % (i - 1) != 0 && RoomZ % (j - 1) != 0) ? 1 : 2;
                                }
                            }
                        }
                        RoomCount++;
                        CreateCorridors(Room);
                    }
                }
            }
            Debug.Log("Room");

    }

    public void CreateCorridors(int[,] Room)
    {
        // Так себе код
        for (int i = 0; i < RoomCounter; RoomCounter--)
        {
            for (int x = 0; x < xr; x++)
            {

                for (int z = 0; z < zr; z++)
                {

                    if (Room[x, z] == 0)
                    {
                        Room[x, z] = Room[x - 1, z] == 2 || Room[x, z - 1] == 2 || Room[x - 1, z - 1] == 2 || Room[x + 1, z] == 2 || Room[x, z + 1] == 2 || Room[x + 1, z + 1] == 2 || Room[x - 1, z + 1] == 2 || Room[x + 1, z - 1] == 2 ? 1 : 0;
                    }
                    if (Room[x, z] == 2 || Room[x, z] == 4)
                    {
                        Instantiate(Plane2, new Vector3(x, 4, z), Quaternion.identity);
                    }
                    if (Room[x, z] == 1)
                    {
                        Instantiate(Plane, new Vector3(x, 4, z), Quaternion.identity);
                    }
                }
            }
            Debug.Log("Corridors");
            Debug.Log(RoomCounter);
            CreateRoom(Room);
        }
    }
}