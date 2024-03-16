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
        path = Path.Combine(Application.dataPath, "Data.json"); // json 데이터 저장 경로
    }
    /// <summary>
    /// 씬의 큐브 데이터들 모두 가져오기
    /// </summary>
    public void GetCubeDataList()
    {
        cubeDataList = new List<CubeData>();
        foreach (GameObject cube in CubeManager.cubeList)
        {
            cubeData = new CubeData(cube.transform.position, cube.transform.rotation, cube.name);
            cubeDataList.Add(cubeData);
        }
    }
    /// <summary>
    /// 저장하기
    /// </summary>
    public void SaveData()
    {
        GetCubeDataList();
        data = new Data(CubeManager.score, OutBox.hp, core.transform.rotation,
            cubeDataList);
        try
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json); // 파일 쓰기
            Debug.Log("데이터 저장 완료");
        }
        catch (Exception e)
        {
            Debug.LogError("데이터 저장 실패: " + e.Message);
        }
    }
    /// <summary>
    /// 로드하기
    /// </summary>
    public void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path); // 파일 읽기
            data = JsonUtility.FromJson<Data>(json);
            foreach (var cube in CubeManager.cubeList)
            {
                Destroy(cube); // 큐브 모두 삭제
            }

            CubeManager.cubeList = new List<GameObject>();
            scoreText.text = data.score.ToString();
            hpText.text = data.hp.ToString();
            core.transform.rotation = data.coreRotation;
            
            foreach (var cd in data.cubeDataList)
            {
                GameObject nowCube = Instantiate(
                    CubeManager.preCubes[(int)Math.Log(int.Parse(cd.name.Replace("(Clone)", "")), 2) -1],
                    cd.position, cd.rotation); // 프리펩에서 가져오기
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
    public int score; // 점수
    public int hp; // 체력
    public Quaternion coreRotation; // 벽 로테이션
    public List<CubeData> cubeDataList; // 큐브 정보 리스트
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
    public Vector3 position; // 포지션
    public Quaternion rotation; // 로테이션
    public string name; // 이름(프리펩가져오기위해)

    public CubeData(Vector3 position, Quaternion rotation, string name)
    {
        this.position = position;
        this.rotation = rotation;
        this.name = name;
    }
}
