using UnityEngine;
using System.Collections;

public class JsonLoad : MonoBehaviour {

    private static JSONObject spritesData;


    private void Awake()
    {
        StartCoroutine(LoadData());
    }
    public  IEnumerator LoadData()
    {
        TextAsset asset = Resources.Load("sprites") as TextAsset;
        spritesData = new JSONObject(asset.text);
        foreach (string key in spritesData.keys) {
            string title = (spritesData[key]["title"]).str;
            Material mat = (Resources.Load("Material/"+key,typeof(Material)))as Material;
            GameObject frame = GameObject.Find(key);
            frame.GetComponent<MeshRenderer>().material = mat;
            frame.transform.GetChild(0).GetComponentInChildren<TextMesh>().text = title;

        }
        yield return null;
    }
}
