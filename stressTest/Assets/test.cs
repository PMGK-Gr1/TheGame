using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	private float time, frameRate;
	private int countFrames;
	
	private float phyObjects = 0, meshes = 0, meshesWCollider = 0, particles = 0;
	private GUIStyle myStyle = new GUIStyle();
	private int c1 = 0, c2 = 0, c3 = 0, c4 = 0;
	
	public GameObject mesh;
	public GameObject phyObject;
	public GameObject particle;

	private float mulMesh = 5.0f, mulColliders = 5.0f, mulRigid = 1.0f, mulParticles = 1.0f;

	private const int btnW = 200, btnH = 200, margin = 20;
	// Use this for initialization
	void Start () {
		frameRate = 0;
		myStyle.fontSize = 20;
		myStyle.fontStyle = FontStyle.Normal;
		myStyle.normal.textColor = Color.white;
		myStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 0f, 0f, 0.5f ) );
		Random.seed = 5;

		int dec = 10;
		mulMesh /= dec;
		mulColliders /= dec;

		mulRigid /= dec;
		mulParticles /= dec;
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
		if(GUI.RepeatButton(new Rect(margin, margin, btnW, btnH), "More..."))
		{
			meshes += mulMesh;
			meshesWCollider += mulColliders;
			phyObjects += mulRigid;
			particles += mulParticles;

			if (meshes > 1)
			{
				//Debug.Log(meshes.ToString());
				for (int i = 0; i < meshes; i++)
				{
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.collider.enabled = false;
					cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 8 - 3, (100*Random.value) % 260.0f);

					if (i + 2 > meshes) 
					{
						c1 += (int)meshes;
						meshes -= i;
					}
				}

			}

			if (meshesWCollider > 1)
			{
				for (int i = 0; i < meshesWCollider; i++)
				{
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.collider.enabled = true;
					cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 8 - 3, (100*Random.value) % 260.0f);

					if (i + 2 > meshesWCollider) 
					{
						c2 += (int)meshesWCollider;
						meshesWCollider -= i;
					}
				}
			}

			if (phyObjects > 1)
			{
				for (int i = 0; i < phyObjects; i++)
				{
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.AddComponent("Rigidbody");
					
					cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 20 - 3, (100*Random.value) % 260.0f);

					if (i + 2 > phyObjects) 
					{
						c3 += (int)phyObjects;
						phyObjects -= i;
					}
				}
			}

			if (particles > 1)
			{
				for (int i = 0; i < particles; i++)
				{
					GameObject particle1 = new GameObject("Particle Test");
					particle1.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 20 - 3, (100*Random.value) % 260.0f);
					particle1.AddComponent("ParticleSystem");

					if (i + 2 > particles) 
					{
						c4 += (int)particles;	
						particles -= i;
					}
				}
			}
		}
		/*
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
		}
		
		if(GUI.RepeatButton(new Rect(margin, 2*margin + btnH, btnW, btnH), "Create meshes with colliders."))
		{
			eshesWCollider += 10;
			for (int i = 0; i < 10; i++)
			{
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.collider.enabled = true;
				cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 8 - 3, (100*Random.value) % 260.0f);
			}
		}
		
		//Column 2
		if(GUI.RepeatButton(new Rect(2*margin + btnW, margin, btnW, btnH), "Create meshes with rigidBody."))
		{
			phyObjects++;
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent("Rigidbody");
			
			cube.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 20 - 3, (100*Random.value) % 260.0f);
		}
		
		if(GUI.RepeatButton(new Rect(2*margin + btnW, 2*margin + btnH, btnW, btnH), "Create particles."))
		{
			particles++;
			GameObject particle1 = new GameObject("Particle Test");
			particle1.transform.position = new Vector3((1000*Random.value) % 18 - 9.0f, (100*Random.value) % 20 - 3, (100*Random.value) % 260.0f);
			particle1.AddComponent("ParticleSystem");
			
		}
		
		//Column 3
		if(GUI.RepeatButton(new Rect(3*margin + 2*btnW, margin, btnW, btnH), "Reset."))
		{
			Application.LoadLevel(Application.loadedLevel);
			
		}
		
		//Column 1
		GUI.Label(new Rect(50, 50, 100, 30), meshes.ToString(), myStyle);
		GUI.Label(new Rect(50, 50 + margin + btnH, 100, 30), meshesWCollider.ToString(), myStyle);
		
		
		//Column 2
		GUI.Label(new Rect(50 + 2*margin + btnW, 50, 100, 30), phyObjects.ToString(), myStyle);
		GUI.Label(new Rect(50 + 2*margin + btnW, 50 + margin + btnH, 100, 30), particles.ToString(), myStyle);
		*/
		//Column 3
		GUI.Box(new Rect(3*margin + 2*btnW, 2*margin + btnH, btnW, btnH),  "FPS: " + frameRate.ToString()  + 
			"\nMalloc: " + Profiler.GetTotalAllocatedMemory()/1000 +
			"\nHeap Size: " + Profiler.GetMonoHeapSize()/1000 + 
			"\nUsed Size: " + Profiler.GetMonoUsedSize()/1000 +
	        "\nMeshes: " + c1 +
	        "\nColliders:: " + c2 +
	        "\nRigidbodies: " + c3 +
	        "\nParticles: " + c4, myStyle);
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
