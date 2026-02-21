using NUnit.Framework.Interfaces;
using UnityEngine;

public class ReferesherScript : MonoBehaviour
{
    public void Start()
    {
        Debug.Log(SampleIterativeFunction(12));
    }

    public int SampleIterativeFunction(int i)
    {
        int result = i % 2;

        if (result == 0)
        {
            return SampleIterativeFunction(i / 2);
        }

        return i;
    }
}
