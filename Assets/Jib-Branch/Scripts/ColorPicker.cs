using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour {

    // Color palette texture
    public Texture2D colorPalettes;
    // Number of rows in color palette texture
    [SerializeField]
    private int rowNumber;
    // Number of columns in color palette texture
    [SerializeField]
    private int columnNumber;
    [SerializeField]
    // Size of texture
    public int textureSize;

    // List of all colors
    private Color32[] colorList;
    // Total number of colors
    private int totalColorNum;
    // Currently selected color
    private Color32 selectedColor;

    //show selected color
    public UnityEngine.UI.Image selectedColorImg;
    // count for color array
    private int count;
    // color offsets for meshes
    private Vector2[] colorOffsets;

    void OnEnable()
    {
        if(colorList == null)
        {
            CreateColorArrays();
        }

        selectedColorImg.color = colorList[0];
    }

    private void CreateColorArrays()
    {
        totalColorNum = rowNumber * columnNumber;
        colorList = new Color32[totalColorNum];
        colorOffsets = new Vector2[totalColorNum];
        int totalCount = 0;
        for(int x = 0; x < rowNumber; x++)
        {
            for(int y = 0; y < columnNumber; y++)
            {
                // Get color values, and offsets
                colorList[totalCount] = SampleTexture(((x + 1f) / rowNumber), ((y + 1f) / columnNumber));
                colorOffsets[totalCount] = new Vector2(((float)(x) / rowNumber), ((float)(y) / columnNumber));
                totalCount++;
            }
        }
    }

    //USED FOR THE UI!!!
    //apply to the increment and decrement buttons to move through the array of colors
    public void ChangeColor(int num)
    {
        count += num;
        if (count < 0)  //checks to make sure we never go below index value of 0
            count = 0;
        if (count > totalColorNum - 1) //checks to make sure we never go about the index value of the total number of colors - 1
            count = totalColorNum - 1;

        selectedColorImg.color = colorList[count];    //applies the color to the preview texture
    }

    private Color32 SampleTexture(float xOffset, float yOffset)
    {
        Color32 color = colorPalettes.GetPixel((int)(xOffset * textureSize) - 5, (int)(yOffset * textureSize) - 5);
        return color;
    }

    public void ApplyColorToLineRender(GameObject renderer)
    {
        renderer.GetComponent<MeshRenderer>().material.color = colorList[count];
    }
}
