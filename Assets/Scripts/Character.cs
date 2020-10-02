using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Character : MonoBehaviour
{
    #region Editor Variables
    //[SerializeField]
    //[Tooltip("The text component that is displaying the score. The text value " +
    //   "of this component will change with the score.")]
    //private Text m_UIText;
    #endregion

    #region Non-Editor Variables
    private int m_ch;
    #endregion

    #region Singletons
    private static Character ch;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        ch = this;
    }

    public void Start()
    {
        m_ch = 1;
    }
    #endregion

    #region Accessors and Mutators
    public static Character Singleton
    {
        get { return ch; }
    }
    public int getCharacterInt()
    {
        return m_ch;
    }
    #endregion

    #region Character Modification Methods
    public void setCharacter(int newCh)
    {
        m_ch = newCh;
    }
    #endregion
}
