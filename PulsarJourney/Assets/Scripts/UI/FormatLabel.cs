using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FormatLabel : MonoBehaviour
{
    public string localizationKey = "";
    public string[] values;

    public string[] localizationKeys;
    public FormatValues[] formatValues;

    [System.Serializable]
    public class FormatValues
    {
        string[] m_values;
    }

    void Start()
    {
        Refresh();
    }
    
    public void Refresh()
    {
        if ( GetComponent<Text>() != null )
        {
            string currentTextVal = GetComponent<Text>().text;
            GetComponent<Text>().text = string.Format(( localizationKey == "" ? currentTextVal : Localization.Get(localizationKey) ), values);

            if ( formatValues != null && formatValues.Length > 0 && localizationKey != null && localizationKey.Length > 0 )
            {
                string finalTextValue = "";
                for ( int i = 0 ; i < localizationKeys.Length ; i++ )
                {
                    finalTextValue += string.Format(( Localization.Get(localizationKeys[ i ]) ), formatValues[i]);
                    finalTextValue += " ";
                }

                GetComponent<Text>().text = finalTextValue;
            }
        }
    }
}
