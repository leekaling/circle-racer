using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Character2 : MonoBehaviour
{
    #region Editor Variables
    //[SerializeField]
    //[Tooltip("The text component that is displaying the score. The text value " +
    //   "of this component will change with the score.")]
    //private Text m_UIText;
    #endregion

    #region Non-Editor Variables
    private int m_ch2;
    #endregion

    #region Singletons
    private static Character2 ch2;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        ch2 = this;
    }

    public void Start()
    {
        m_ch2 = 1;
    }
    #endregion

    #region Accessors and Mutators
    public static Character2 Singleton
    {
        get { return ch2; }
    }
    public int getCharacterInt()
    {
        return m_ch2;
    }
    #endregion

    #region Character Modification Methods
    public void setCharacter(int newCh)
    {
        m_ch2 = newCh;
    }
    #endregion
}