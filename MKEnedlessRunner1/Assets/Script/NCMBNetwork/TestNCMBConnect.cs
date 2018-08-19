using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class TestNCMBConnect : MonoBehaviour {
    public Text Name;
    public Text result;
    public InputField inputField;

    public void DemoNCMBConnect()
    {
        NCMBObject ncmbObj = new NCMBObject("TestClass");
        if (inputField.text != null) { ncmbObj["name"] = inputField.text; }
        else { ncmbObj["name"] = "Test"; }
        ncmbObj["message"] = "Hello NCMB !!!";

        ncmbObj.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                result.text += "保存に失敗しました。\n ErrorCode : " + (string)e.ErrorMessage + "\n";
                Debug.Log("保存に失敗: " + e.ErrorMessage);
            }
            else
            {
                Name.text = ncmbObj["name"].ToString();
                result.text += "保存に成功しました。\n objectId : " + (string)ncmbObj.ObjectId + "\n";
                Debug.Log("保存に成功");
            }

        });


    }
}
