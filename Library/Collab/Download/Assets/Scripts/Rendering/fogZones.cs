using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Zones/FogZones")]

public class fogZones : MonoBehaviour {

    private fogHandler fh;
	public Color zoneFogColor;
    public bool inFog;

    public float zoneFogDensity;
    private SphereCollider c;

    public float VolumeDistance;

    private GameObject player;

	void Start () {
        if (GetComponent<SphereCollider>())
        {
            c = GetComponent<SphereCollider>();
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Collider>().gameObject;
        fh = FindObjectOfType<fogHandler>();
    }
	void SetTargetVals()
    {
		if (inFog)
        {
            fh.currentColor = zoneFogColor;
            fh.currentDensity = zoneFogDensity;
        } 
        else
        {
            fh.currentColor = fh.defaultColor;
            fh.currentDensity = fh.defaultDensity;
        }
	}

    private void FixedUpdate()
    {
        if (c)
        {
            float d = Vector3.Distance(this.transform.position, player.transform.position);
            if (((d - c.radius) < VolumeDistance - c.radius) && (d > c.radius) && (d < VolumeDistance))
            {
                float dc = (d - c.radius); //distance from player to edge of inner sphere
                float db = VolumeDistance - c.radius - dc;  //distance from volume outer edge to player, within volume

                RenderSettings.fogDensity = (db / (dc + db)) * (zoneFogDensity - fh.defaultDensity) + fh.defaultDensity;
                RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, fh.currentColor, LerpValue(dc, VolumeDistance - c.radius));
            }
        }
    }

    float LerpValue(float dist, float maxDist)
    {
        return dist / maxDist;
    }

    void OnTriggerEnter(Collider col){
		if (col.gameObject == player) {
			inFog = true;
            SetTargetVals();
		} 
	}

	public void OnTriggerExit(Collider col){
		if (col.gameObject == player) {
			inFog = false;
            SetTargetVals();
        }
	}
}