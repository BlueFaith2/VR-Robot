using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public GameObject corpPrefab;
	public GameObject gatPrefab;
	public GameObject capPrefab;
	public GameObject umarPrefab;
	public GameObject ochiPrefab;
	public GameObject bratPrefab;
	public GameObject anteBratPrefab;
	public GameObject cotPrefab;
	public GameObject bucaPrefab;
	public GameObject pulpaPrefab;
	public GameObject coapsaPrefab;

	private GameObject corp;
	private GameObject corp_node;

	//Nodes and Objects for head
	private GameObject cap;
	private GameObject gat;
	private GameObject cap_node;
	private GameObject ochiStang;
	private GameObject ochiDrept;

	//Nodes and Objects for Left Arm
	private GameObject umarStang_node;
	private GameObject umarStang;
	private GameObject bratStang;
	private GameObject cotStang_node;
	private GameObject cotStang;
	private GameObject anteBratStang;

	//Nodes and Objects for Right Arm
	private GameObject umarDrept_node;
	private GameObject umarDrept;
	private GameObject bratDrept;
	private GameObject cotDrept_node;
	private GameObject cotDrept;
	private GameObject anteBratDrept;

	//Nodes and Objects for Left Foot
	private GameObject bucaStanga_node;
	private GameObject bucaStanga;
	private GameObject pulpaStanga;
	private GameObject genunchiStang_node;
	private GameObject genunchiStang;
	private GameObject coapsaStanga;

	//Nodes and Objects for Right Foot
	private GameObject bucaDreapta_node;
	private GameObject bucaDreapta;
	private GameObject pulpaDreapta;
	private GameObject genunchiDrept_node;
	private GameObject genunchiDrept;
	private GameObject coapsaDreapta;

	//Variables for use
	public int angle = 0;
	public int prev = 0;
	public int angle2 = 0;
	public int step = 1;
	public int step2 = 1;
	public int max = 30;
	public int max2 = 60;
	public int min = -30;
	public int min2 = -30;
		
	// Use this for initialization
	void Start () {
		//Instantiate node for corp and corp object
		corp_node = new GameObject ("Corp_node");
		corp_node.transform.position = Vector3.up * 5;
		corp = (GameObject) Instantiate (corpPrefab, corp_node.transform.position, Quaternion.Euler (0, 0, 0), corp_node.transform);

		//Instantiate node for cap/gat and cap/gat object
		cap_node = new GameObject ("Cap_node");
		cap_node.transform.parent = corp_node.transform;
		cap_node.transform.position = corp.transform.position + Vector3.up*1.75f;
		gat = (GameObject)Instantiate (gatPrefab, cap_node.transform.position, Quaternion.Euler (0, 0, 0), cap_node.transform);
		cap = (GameObject)Instantiate (capPrefab, cap_node.transform.position + Vector3.up/2, Quaternion.Euler (0, 0, 0), cap_node.transform);
		ochiStang = (GameObject)Instantiate (ochiPrefab, cap_node.transform.position + Vector3.forward/2 + Vector3.left/4 + Vector3.up/1.5f, Quaternion.Euler (0, 0, 0), cap_node.transform);
		ochiDrept = (GameObject)Instantiate (ochiPrefab, cap_node.transform.position + Vector3.forward/2 + Vector3.right/4 + Vector3.up/1.5f, Quaternion.Euler (0, 0, 0), cap_node.transform);

		//Instantiate node for umar stang and subsequent nodes/objects
		umarStang_node = new GameObject("UmarStang_node");
		umarStang_node.transform.parent = corp_node.transform;
		umarStang_node.transform.position = corp.transform.position + Vector3.left*1.25f + Vector3.up*1.33f;
		umarStang = (GameObject) Instantiate (umarPrefab, umarStang_node.transform.position, Quaternion.Euler (0, 0, 0), umarStang_node.transform);
		bratStang = (GameObject) Instantiate (bratPrefab, umarStang_node.transform.position + Vector3.left * 0.1f + Vector3.down, Quaternion.Euler (0, 0, 0), umarStang_node.transform);
		cotStang_node = new GameObject("CotStang_node");
		cotStang_node.transform.parent = umarStang_node.transform;
		cotStang_node.transform.position = umarStang_node.transform.position + Vector3.left * 0.1f + Vector3.down*1.75f;
		cotStang = (GameObject) Instantiate (cotPrefab, cotStang_node.transform.position, Quaternion.Euler (0, 0, 0), cotStang_node.transform);
		anteBratStang = (GameObject) Instantiate (anteBratPrefab, cotStang_node.transform.position + Vector3.down/2, Quaternion.Euler (0, 0, 0), cotStang_node.transform);

		//Instantiate node for umar drept and subsequent nodes/objects
		umarDrept_node = new GameObject("UmarDrept_node");
		umarDrept_node.transform.parent = corp_node.transform;
		umarDrept_node.transform.position = corp.transform.position + Vector3.right*1.25f + Vector3.up*1.33f;
		umarDrept = (GameObject) Instantiate (umarPrefab, umarDrept_node.transform.position, Quaternion.Euler (0, 0, 0), umarDrept_node.transform);
		bratDrept = (GameObject) Instantiate (bratPrefab, umarDrept_node.transform.position + Vector3.right * 0.1f + Vector3.down, Quaternion.Euler (0, 0, 0), umarDrept_node.transform);
		cotDrept_node = new GameObject("CotDrept_node");
		cotDrept_node.transform.parent = umarDrept_node.transform;
		cotDrept_node.transform.position = umarDrept_node.transform.position + Vector3.right * 0.1f + Vector3.down*1.75f;
		cotDrept = (GameObject) Instantiate (cotPrefab, cotDrept_node.transform.position, Quaternion.Euler (0, 0, 0), cotDrept_node.transform);
		anteBratDrept = (GameObject) Instantiate (anteBratPrefab, cotDrept_node.transform.position + Vector3.down/2, Quaternion.Euler (0, 0, 0), cotDrept_node.transform);

		//Instantiate node for buca stanga and subsequent nodes/objects
		bucaStanga_node = new GameObject("bucaStanga_node");
		bucaStanga_node.transform.parent = corp_node.transform;
		bucaStanga_node.transform.position = corp.transform.position + Vector3.down * 2 + Vector3.left*0.5f;
		bucaStanga = (GameObject) Instantiate (bucaPrefab, bucaStanga_node.transform.position, Quaternion.Euler (0, 0, 0), bucaStanga_node.transform);
		pulpaStanga = (GameObject) Instantiate (pulpaPrefab, bucaStanga_node.transform.position + Vector3.down*1.5f, Quaternion.Euler (0, 0, 0), bucaStanga_node.transform);


		//Instantiate node for buca dreapta and subsequent nodes/objects
		bucaDreapta_node = new GameObject("bucaDreapta_node");
		bucaDreapta_node.transform.parent = corp_node.transform;
		bucaDreapta_node.transform.position = corp.transform.position + Vector3.down * 2 + Vector3.right*0.5f;
		bucaDreapta = (GameObject) Instantiate (bucaPrefab, bucaDreapta_node.transform.position, Quaternion.Euler (0, 0, 0), bucaDreapta_node.transform);
		pulpaDreapta = (GameObject) Instantiate (pulpaPrefab, bucaDreapta_node.transform.position + Vector3.down*1.5f, Quaternion.Euler (0, 0, 0), bucaDreapta_node.transform);
	}
	
	// Update is called once per frame
	void Update () {
		prev = angle;
		angle += step;
		if (angle > max) {
			angle = max;
			step *= -1;
		} else {
			if (angle < min) {
				angle = min;
				step *= -1;
			}
		}
			
		angle2 += step2;
		if (angle2 > max) {
			angle2 = max;
			step2 *= -1;
		} else {
			if (angle2 < min2) {
				angle2 = min2;
				step2 *= -1;
			}
		}


		umarDrept_node.transform.rotation = Quaternion.Euler (-angle, 0, 0);
		umarStang_node.transform.rotation = Quaternion.Euler (angle, 0, 0);
		bucaDreapta_node.transform.rotation = Quaternion.Euler (angle, 0, 0);
		bucaStanga_node.transform.rotation = Quaternion.Euler (-angle, 0, 0);
		cotDrept_node.transform.rotation = Quaternion.Euler (-angle2, 0, 0);
		cotStang_node.transform.rotation = Quaternion.Euler (-angle2, 0, 0);
	}
}
