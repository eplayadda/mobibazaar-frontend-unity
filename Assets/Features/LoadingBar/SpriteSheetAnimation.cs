using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetAnimation : MonoBehaviour {

    //The file location of the sprites within the resources folder
    public string _location;
    public float _frameSeconds = 1;
    public bool _loop;

    private SpriteRenderer mRenderer;
    private Sprite[] mSprites;
    private int mFrame = 0;
    private float mDeltaTime = 0;

    // Use this for initialization
    void Start()
    {
        mRenderer = GetComponent<SpriteRenderer>();
        mSprites = Resources.LoadAll<Sprite>(_location);
    }

    // Update is called once per frame
    void Update()
    {
        //Keep track of the time that has passed
        mDeltaTime += Time.deltaTime;

        /*Loop to allow for multiple sprite frame 
         jumps in a single update call if needed
         Useful if frameSeconds is very small*/
        while (mDeltaTime >= _frameSeconds)
        {
            mDeltaTime -= _frameSeconds;
            mFrame++;
            if (_loop)
                mFrame %= mSprites.Length;
            //Max limit
            else if (mFrame >= mSprites.Length)
                mFrame = mSprites.Length - 1;
        }
        //Animate sprite with selected frame
        if(mRenderer != null)
            mRenderer.sprite = mSprites[mFrame];
    }
}
