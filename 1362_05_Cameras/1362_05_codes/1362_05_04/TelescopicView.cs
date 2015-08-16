using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

/* ----------------------------------------
 * class to demonstrate how to implement
 * a telescopic view on the main camera
 */
public class TelescopicView : MonoBehaviour
{
    // float variable for maximum amount of zoom (e.g: 2.0 = image twice as big)
    public float zoom = 2.0f;
    // float variable for speed of zoom-in transition
    public float speedIn = 100.0f;
    // float variable for speed of zoom-out transition
    public float speedOut = 100.0f;
    // float variable for the inital value of the camera's FOV (Field-Of-View)
    private float initFov;
    // float variable for the current value of the camera's FOV (Field-Of-View) at runtime
    private float currFov;
    // float variable for the minimum value of the camera's FOV (Field-Of-View) allowed (the smaller the FOV, the higher the Zoom level)
    private float minFov;
    // float variable for the amount of FOV to be added or subracted per frame, at runtime
    private float addFov;
    // VignetteAndChromaticAberration variable for referencing image effect 
    private VignetteAndChromaticAberration v;
    // float variable for the maximum intensity of vignetting allowed 
    public float vMax = 10.0f;

    /* ----------------------------------------
     * At Start, set 'initFov' as the Camera's FOV level, calculate 'minFov'.
     * Also, store the Vignette And Chromatic Aberration image effect attached to the camera in a variable
     */
    void Start()
    {
        // set 'initFov' as the Camera's FOV level
        initFov = Camera.main.fieldOfView;

        // calculate the minimum FOV allowed by dividing the initial FOV by the maximum Zooming alllowed
        minFov = initFov / zoom;

        // create shorthand for the Vignette And Chromatic Aberration image effect attached to the camera
        v = this.GetComponent<VignetteAndChromaticAberration>() as VignetteAndChromaticAberration;
    }

    /* ----------------------------------------
     * During Update, detect status of the left mouse button, calling the appropriate function (ZoomView, if pressed; ZoomOut if not)
     * Also, adjust Vignette And Chromatic Aberration image effect intensity according to camera's FOV
     */
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            // IF the left mouse button is down, THEN call ZoomView function
            ZoomView();
        else
            // ELSE, IF the left mouse button is not down, THEN call ZoomOut function
            ZoomOut();

        // A float variable for the difference between the current FOV level and the initial FOV level
        float currDistance = currFov - initFov;

        //A float variable for the difference between minimum FOV allowed and the initial FOV level
        float totalDistance = minFov - initFov;

        // A float variable for the proportion between the current difference and the maximum distance between FOV levels
        float vMultiplier = currDistance / totalDistance;

        // A float value for the intensity of the vignette effect, product of the maximum allowed by the 'vMultiplier'
        float vAmount = vMax * vMultiplier;

        // Clamp vignette intensity level between 0 and maximum allowed
        vAmount = Mathf.Clamp(vAmount, 0, vMax);

        // Set vignette intensity level to appropriate amount
        v.intensity = vAmount;
    }

    /* ----------------------------------------
     * A function to Zoom-in by decreasing the FOV
     */
    void ZoomView()
    {
        // Get current Camera's FOV and pass it to 'currFov' variable
        currFov = Camera.main.fieldOfView;

        // Get amount of FOV to be subtracted from camera by multiplying zoom-in speed by Time.deltaTime
        addFov = speedIn * Time.deltaTime;

        if (Mathf.Abs(currFov - minFov) < 0.5f)
            // IF difference bewtween current FOV and minimum allowed FOV is smaller than 0.5, THEN set current FOV as minFov
            currFov = minFov;

        else if (currFov - addFov >= minFov)
            // ELSE, if current FOV minus amount to be subtracted from it is greater or equal to minimum allowed FOV, THEN subtract from FOV
            currFov -= addFov;

        // Set Camera's FOV to currFov value 
        Camera.main.fieldOfView = currFov;
    }

    /* ----------------------------------------
     * A function to Zoom-out by increasing the FOV
     */
    void ZoomOut()
    {
        // Get current Camera's FOV and pass it to 'currFov' variable
        currFov = Camera.main.fieldOfView;

        // Get amount of FOV to be added to camera by multiplying zoom-out speed by Time.deltaTime
        addFov = speedOut * Time.deltaTime;

        if (Mathf.Abs(currFov - initFov) < 0.5f)
            // IF difference bewtween current FOV and initial FOV is smaller than 0.5, THEN set current FOV to initial FOV value
            currFov = initFov;

        else if (currFov + addFov <= initFov)
            // ELSE, if current FOV plus amount to be added to it is smaller or equal to initial FOV, THEN add to FOV
            currFov += addFov;

        // Set Camera's FOV to currFov value
        Camera.main.fieldOfView = currFov;
    }
}

