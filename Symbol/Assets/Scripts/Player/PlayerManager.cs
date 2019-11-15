using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー情報(設定)
/// </summary>
[System.Serializable]
public struct PlayerStatus
{
    public int MaxHP;
    public int Hp;
    public int Attack;

    public Dictionary<CrystalInfo.Data, int> CrystalBag;

}

/// <summary>
/// プレイヤー管理クラス
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public PlayerStatus status;
    /// <summary>
    /// プレイヤー情報(管理)
    /// </summary>
    public PlayerStatus GetStatus { get { return status; } }

    /// <summary>
    /// プレイヤー情報更新
    /// </summary>
    /// <param name="data"></param>
    public void ApplyStatus(PlayerStatus data)
    {
        status = data;
    }

    [SerializeField]
    private CrystalDataList m_dataList;

    private Vector3 m_movePosition = Vector3.zero;

    [SerializeField] private float m_moveSpeed = 0;

    [SerializeField] private GameObject gameObject = null;

    private bool m_isMove = false;

    //void Update() {
    //    //if (Input.GetKeyDown(KeyCode.Space)) {
    //    //    Dictionary<CrystalInfo.Data, int> tempData = new Dictionary<CrystalInfo.Data, int>();
    //    //    foreach(var i in dataList.CrystalData) {
    //    //        tempData.Add(i.Value, 1);
    //    //    }
    //    //    PlayerStatus pStatus = new PlayerStatus();
    //    //    pStatus.CrystalBag = tempData;
    //    //    ApplyStatus(pStatus);
    //    //    Debug.Log("データイレタヨ");
    //    //}
    //}

    private void MoveUpdate()
    {
        if (!m_isMove) { return; }
        this.transform.position += this.transform.forward * m_moveSpeed * Time.deltaTime;

        if(Vector3.Distance(this.transform.position, m_movePosition) > 1f) { return; }
        m_isMove = false;
        m_movePosition = Vector3.zero;
    }

    private void MouseUpdate()
    {
        if (!Input.GetMouseButtonDown(0)) { return; }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycast;

        if (!Physics.Raycast(ray, out raycast)) { return; }
        if(raycast.transform.tag == "Ground")
        {
            m_movePosition = raycast.point;
            m_isMove = true;
            gameObject.transform.position = m_movePosition;

            m_movePosition.y = this.transform.position.y;
            this.transform.LookAt(m_movePosition);
            return;
        }

        if (raycast.transform.tag == "Enemy")
        {
            raycast.transform.gameObject.GetComponent<TestSetShaderParame>().OutLine();

            m_movePosition = raycast.point;
            m_isMove = true;
            gameObject.transform.position = m_movePosition;

            m_movePosition.y = this.transform.position.y;
            this.transform.LookAt(m_movePosition);
            return;
        }
    }

    private void FixedUpdate()
    {
        MouseUpdate();
        MoveUpdate();
    }
}
