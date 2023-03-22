using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{

    public static GameObject FindInChildrenIncludingInactive(GameObject go, string name)
    {

        for (int i = 0; i < go.transform.childCount; i++)
        {
            if (go.transform.GetChild(i).gameObject.name == name) return go.transform.GetChild(i).gameObject;
            GameObject found = FindInChildrenIncludingInactive(go.transform.GetChild(i).gameObject, name);
            if (found != null) return found;
        }

        return null;
    }

    public static GameObject FindIncludingInactive(string name)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!scene.isLoaded)
        {
            //no scene loaded
            return null;
        }

        List<GameObject> game_objects = new List<GameObject>();
        scene.GetRootGameObjects(game_objects);

        foreach (GameObject obj in game_objects)
        {
            if (obj.transform.name == name) return obj;

            GameObject found = FindInChildrenIncludingInactive(obj, name);
            if (found) return found;
        }

        return null;
    }



    public GameObject countdown()
    {
        Utils.FindIncludingInactive("Three").SetActive(true);
        StartCoroutine(twoSecondDelay());
        Utils.FindIncludingInactive("Three").SetActive(false);
        Utils.FindIncludingInactive("Two").SetActive(true);
        StartCoroutine(twoSecondDelay());
        Utils.FindIncludingInactive("Two").SetActive(false);
        Utils.FindIncludingInactive("One").SetActive(true);
        StartCoroutine(twoSecondDelay());
        Utils.FindIncludingInactive("One").SetActive(false);
        Utils.FindIncludingInactive("Go").SetActive(true);
        StartCoroutine(twoSecondDelay());
        Utils.FindIncludingInactive("Go").SetActive(false);
        return null;
    }

    IEnumerator twoSecondDelay()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
