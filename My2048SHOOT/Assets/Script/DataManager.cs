using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
    private string path;
    private Data data;
    private CubeData cubeData;
    private List<CubeData> cubeDataList;

    public GameObject core;
    public GameObject cubeParents; // cubeManager
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        path = Path.Combine(Application.dataPath, "Data.json");
    }

    public void GetCubeDataList()
    {
        cubeDataList = new List<CubeData>();
        foreach (GameObject cube in CubeManager.cubeList)
        {
            cubeData = new CubeData(cube.transform.position, cube.transform.rotation, cube.name);
            cubeDataList.Add(cubeData);
        }
    }
    
    public void SaveData()
    {
        GetCubeDataList();
        data = new Data(CubeManager.score, OutBox.hp, core.transform.rotation,
            cubeDataList);
        try
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
            Debug.Log("데이터 저장 완료");
        }
        catch (Exception e)
        {
            Debug.LogError("데이터 저장 실패: " + e.Message);
        }
    }
    public void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<Data>(json);
            foreach (var cube in CubeManager.cubeList)
            {
                Destroy(cube);
            }

            CubeManager.cubeList = new List<GameObject>();
            scoreText.text = data.score.ToString();
            hpText.text = data.hp.ToString();
            core.transform.rotation = data.coreRotation;
            //Math.Log(y, 2) - 1
            foreach (var cd in data.cubeDataList)
            {
                GameObject nowCube = Instantiate(
                    CubeManager.preCubes[(int)Math.Log(int.Parse(cd.name.Replace("(Clone)", "")), 2) -1],
                    cd.position, cd.rotation);
                CubeManager.cubeList.Add(nowCube);
            }

        }
        else
        {
            return;
        }
    }
}
[System.Serializable]
public class Data
{
    public int score;
    public int hp;
    public Quaternion coreRotation;
    public List<CubeData> cubeDataList;
    public Data(int score, int hp, Quaternion coreRotation,
        List<CubeData> cubeDataList)
    {
        this.score = score;
        this.hp = hp;
        this.coreRotation = coreRotation;
        this.cubeDataList = new List<CubeData>(cubeDataList);
    }
}
[System.Serializable]
public class CubeData
{
    public Vector3 position;
    public Quaternion rotation;
    public string name;

    public CubeData(Vector3 position, Quaternion rotation, string name)
    {
        this.position = position;
        this.rotation = rotation;
        this.name = name;
    }
}
