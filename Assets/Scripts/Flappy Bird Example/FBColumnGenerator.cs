using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBColumnGenerator : MonoBehaviour
{
    public float width;
    public float minHeight = -1.78f;
    public float maxHeight = 0.81f;

    public List<GameObject> generatedObjects = new List<GameObject>();

    private void Start() {
        GenerateColumns();
    }
    

    public void GenerateColumns() {
        // decide how many columns we want for this generation
        int numOfCoumns = Random.Range(FBGameManager.instance.minMaxNumOfColumns.x, FBGameManager.instance.minMaxNumOfColumns.y);

        // clear the objects of previous generation
        DestroyPreviousGenerationOfColumns();

        // generate new columns
        for (int i=0; i<numOfCoumns; i++)
        {
            GenerateSingleColumn();
        }
             
        
    } 

    private void GenerateSingleColumn() {
        float halfWidth = width / 2;
        Vector3 minGeneretionPosition = -transform.right * halfWidth;
        Vector3 maxGeneretionPosition = transform.right * halfWidth;

        float genPointX = Random.Range(minGeneretionPosition.x, maxGeneretionPosition.x);
        float genPointY = Random.Range(minHeight, maxHeight);

        GameObject prefab = Resources.Load("ColumnShortSprite") as GameObject;
        GameObject column =  Instantiate(prefab, transform);
        column.transform.localPosition = new Vector3(genPointX, genPointY, transform.position.z);

        generatedObjects.Add(column);
    } 

    private void DestroyPreviousGenerationOfColumns() {
        // for (int i=transform.childCount - 1; i>=0; i--) {
        //     Transform child = transform.GetChild(i);

        //     if (child.name.Contains("ColumnShortSprite")) {
        //         Destroy(child.gameObject);
        //     }
        // }

        for (int i=0; i<generatedObjects.Count; i++) {
            Destroy(generatedObjects[i]);
        }
        generatedObjects.Clear();
    }  
}
