using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PS4コントローラーの入力管理
/// </summary>
public class PSInputManager : SingletonMonoBehaviour<PSInputManager>
{
    #region Privare変数

    private bool circleButton = false;
    private bool crossButton = false;
    private bool triangleButton = false;
    private bool squareButton = false;
    private bool l1Button = false;
    private bool l2Button = false;
    private bool l3Button = false;
    private bool r1Button = false;
    private bool r2Button = false;
    private bool r3Button = false;
    private bool optionButton = false;
    private bool shareButton = false;
    private bool psButton = false;
    
    // 十字キー--------------------------
    private float crossKeyHorizontal = 0;
    private float crossKeyVertical = 0;
    // ----------------------------------

    // スティック------------------------
    private float lStickHorizontal = 0;
    private float lStickVertical = 0;
    private float rStickHorizontal = 0;
    private float rStickVertical = 0;
    // ----------------------------------
    #endregion

    #region プロパティ
    /// <summary>
    /// 〇
    /// </summary>
    public bool CircleButton { get => circleButton;}
    /// <summary>
    /// ×
    /// </summary>
    public bool CrossButton { get => crossButton; }
    /// <summary>
    /// △
    /// </summary>
    public bool TriangleButton { get => triangleButton; }
    /// <summary>
    /// ×
    /// </summary>
    public bool SquareButton { get => squareButton; }
    /// <summary>
    /// L1
    /// </summary>
    public bool L1Button { get => l1Button; }
    /// <summary>
    /// L2
    /// </summary>
    public bool L2Button { get => l2Button; }
    /// <summary>
    /// L3
    /// </summary>
    public bool L3Button { get => l3Button; }
    /// <summary>
    /// R1
    /// </summary>
    public bool R1Button { get => r1Button; }
    /// <summary>
    /// R2
    /// </summary>
    public bool R2Button { get => r2Button; }
    /// <summary>
    /// R3
    /// </summary>
    public bool R3Button { get => r3Button; }
    /// <summary>
    /// Option
    /// </summary>
    public bool OptionButton { get => optionButton; }
    /// <summary>
    /// Share
    /// </summary>
    public bool ShareButton { get => shareButton; }
    /// <summary>
    /// PSButton
    /// </summary>
    public bool PsButton { get => psButton; }
    /// <summary>
    /// 十字キー(左右)
    /// </summary>
    public float CrossKeyHorizontal { get => crossKeyHorizontal; }
    /// <summary>
    /// 十字キー(上下)
    /// </summary>
    public float CrossKeyVertical { get => crossKeyVertical; }
    /// <summary>
    /// 右スティック(左右)
    /// </summary>
    public float LStickHorizontal { get => lStickHorizontal; }
    /// <summary>
    /// 右スティック(上下)
    /// </summary>
    public float LStickVertical { get => lStickVertical; }
    /// <summary>
    /// 左スティック(左右)
    /// </summary>
    public float RStickHorizontal { get => rStickHorizontal; }
    /// <summary>
    /// 左スティック(上下)
    /// </summary>
    public float RStickVertical { get => rStickVertical; }



    #endregion

    private void Awake()
    {
        Init();
    }
   
    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        circleButton = false;
        crossButton = false;
        triangleButton = false;
        squareButton = false;
        l1Button = false;
        l2Button = false;
        l3Button = false;
        r1Button = false;
        r2Button = false;
        r3Button = false;
        optionButton = false;
        shareButton = false;
        psButton = false;
        crossKeyHorizontal = 0;
        crossKeyVertical = 0;
        lStickHorizontal = 0;
        lStickVertical = 0;
        rStickHorizontal = 0;
        rStickVertical = 0;
    }

    /// <summary>
    /// 入力の判定
    /// </summary>
    public void InputCheck()
    {
        if (Input.GetButton("Circle")){ circleButton = true; }
        if (Input.GetButton("Cross")){ crossButton = true; }
        if (Input.GetButton("Triangle")) { triangleButton = true; }
        if (Input.GetButton("Square")) { crossButton = true; }
        if (Input.GetButton("L1")) { l1Button = true; }
        if (Input.GetButton("L2")) { l2Button = true; }
        if (Input.GetButton("L3")) { l3Button = true; }
        if (Input.GetButton("R1")) { r1Button = true; }
        if (Input.GetButton("R2")) { r2Button = true; }
        if (Input.GetButton("R3")) { r3Button = true; }
        if (Input.GetButton("Option")) { optionButton = true; }
        if (Input.GetButton("Share")) { shareButton = true; }
        if (Input.GetButton("PS")) { psButton = true; }

        if (Input.GetButtonUp("Circle")) { circleButton = false; }
        if (Input.GetButtonUp("Cross")) { crossButton = false; }
        if (Input.GetButtonUp("Triangle")) { triangleButton = false; }
        if (Input.GetButtonUp("Square")) { crossButton = false; }
        if (Input.GetButtonUp("L1")) { l1Button = false; }
        if (Input.GetButtonUp("L2")) { l2Button = false; }
        if (Input.GetButtonUp("L3")) { l3Button = false; }
        if (Input.GetButtonUp("R1")) { r1Button = false; }
        if (Input.GetButtonUp("R2")) { r2Button = false; }
        if (Input.GetButtonUp("R3")) { r3Button = false; }
        if (Input.GetButtonUp("Option")) { optionButton = false; }
        if (Input.GetButtonUp("Share")) { shareButton = false; }
        if (Input.GetButtonUp("PS")) { psButton = false; }

        crossKeyHorizontal = Input.GetAxis("CrossKeyHorizontal");
        crossKeyVertical = Input.GetAxis("CrossKeyVertical");

        lStickHorizontal = Input.GetAxis("LStickHorizontal");
        lStickVertical = Input.GetAxis("LStickVertical") * -1;
        rStickHorizontal = Input.GetAxis("RStickHorizontal");
        rStickVertical = Input.GetAxis("RStickVertical") * -1;
    }

}
