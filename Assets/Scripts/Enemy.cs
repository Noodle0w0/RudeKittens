using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (karakteriniz)
    public float moveSpeed = 5f; // D��man�n h�z�
    private string enemyKey = "Enemy"; // D��man�n kay�t anahtar�

    private void Update()
    {
        if (target != null)
        {
            // D��man� hedefe do�ru hareket ettirin
            transform.LookAt(target);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }


    #region Save
    public void KaydetDusman()
    {
        // D��man�n konumunu kaydedin
        Vector3 enemyPosition = transform.position;
        PlayerPrefs.SetFloat(enemyKey + "_x", enemyPosition.x);
        PlayerPrefs.SetFloat(enemyKey + "_y", enemyPosition.y);
        PlayerPrefs.SetFloat(enemyKey + "_z", enemyPosition.z);
        PlayerPrefs.Save();
        Debug.Log("D��man kaydedildi: " + enemyPosition);
    }

    public void YukleDusman()
    {
        // Oyunu y�klerken d��man�n kaydedilmi� konumunu kontrol edin
        if (PlayerPrefs.HasKey(enemyKey + "_x") && PlayerPrefs.HasKey(enemyKey + "_y") && PlayerPrefs.HasKey(enemyKey + "_z"))
        {
            float x = PlayerPrefs.GetFloat(enemyKey + "_x");
            float y = PlayerPrefs.GetFloat(enemyKey + "_y");
            float z = PlayerPrefs.GetFloat(enemyKey + "_z");
            Vector3 enemyPosition = new Vector3(x, y, z);
            transform.position = enemyPosition;
        }
    }
    #endregion
}
