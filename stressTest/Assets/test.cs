using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	private float time, frameRate;
	private int countFrames;
	
	private int phyObjects = 0, meshes = 0, meshesWCollider = 0, particles = 0;
	private GUIStyle myStyle = new GUIStyle();
	
	public GameObject mesh;
	public GameObject phyObject;
	public GameObject particle;
	
	private const int btnW = 120, btnH = 100, margin = 10;
	
	// Use this for initialization
	void Start () {
		frameRate = 0;
		myStyle.fontSize = 20;
		myStyle.fontStyle = FontStyle.Normal;
		myStyle.normal.textColor = Color.white;
		myStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 0f, 0f, 0.5f ) );
		Random.seed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		CountFrameRate();
	}
	
	/// <summary>
	/// Raises the GUI event.
	/// </summary>
	void OnGUI ()
	{
		//Column 1
		if(GUI.RepeatButton(new Rect(margin, margin, btnW, btnH), "Create meshes."))
		{
			meshes += 10;
			for (int i = 0; i < 10; i++)
			{
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.collider.enabled = false;
				cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 8 - 3, (100*Random.value) % 260.0f);
			}
			
			//mesh.transform.position.x = 5;
			//mesh.transform.position.y = 10;
			//Instantiate(mesh);
		}
		
		if(GUI.RepeatButton(new Rect(margin, 2*margin + btnH, btnW, btnH), "Colliders"))
		{
			meshesWCollider += 10;
			for (int i = 0; i < 10; i++)
			{
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.collider.enabled = true;
				cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 8 - 3, (100*Random.value) % 260.0f);
			}
			
			//mesh.transform.position.x = 5;
			//mesh.transform.position.y = 10;
			//Instantiate(mesh);
		}
		
		//Column 2
		if(GUI.RepeatButton(new Rect(2*margin + btnW, margin, btnW, btnH), "Rigid Bodies"))
		{
			phyObjects++;
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent("Rigidbody");
			
			cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 20 - 3, (100*Random.value) % 260.0f);
		}
		
		if(GUI.Button(new Rect(2*margin + btnW, 2*margin + btnH, btnW, btnH), "Create particles."))
		{
			particles++;
			GameObject particle1 = (GameObject)Instantiate(particle, new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 20 - 3, (100*Random.value) % 260.0f), Quaternion.identity);
		}
		
		//Column 3
		if(GUI.RepeatButton(new Rect(3*margin + 2*btnW, margin, btnW, btnH), "Reset."))
		{
			Application.LoadLevel(Application.loadedLevel);
			
		}
		
		//Column 1
		GUI.Label(new Rect(30, 30, 80, 20), meshes.ToString(), myStyle);
		GUI.Label(new Rect(30, 30 + margin + btnH, 80, 20), meshesWCollider.ToString(), myStyle);
		
		
		//Column 2
		GUI.Label(new Rect(20 + 2*margin + btnW, 30, 90, 20), phyObjects.ToString(), myStyle);
		GUI.Label(new Rect(30 + 2*margin + btnW, 30 + margin + btnH, 90, 20), particles.ToString(), myStyle);
		
		//Column 3
		GUI.Box(new Rect(3*margin + 2*btnW, 2*margin + btnH, btnW+50, btnH),  "FPS: " + frameRate.ToString()  + 
			"\nMalloc: " + Profiler.GetTotalAllocatedMemory()/1000, myStyle);
		
		
	}
	
	/// <summary>
	/// Counts the frame rate.
	/// </summary>
	void CountFrameRate ()
	{
		if (countFrames < 10)
		{
			countFrames++;
			time += Time.deltaTime;			
		}
		else
		{
			countFrames = 0;
			frameRate = 10/time;
			time = 0;
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col )
	{
	    Color[] pix = new Color[width * height];
	    for( int i = 0; i < pix.Length; ++i )
	    {
	        pix[ i ] = col;
		}
	    
	    Texture2D result = new Texture2D( width, height );
	    result.SetPixels( pix );
	    result.Apply();
	    return result;

	}

}
