using UnityEngine;
using System.Collections;

public class Questions : MonoBehaviour {
	
	public bool fullInspectionPrerequisite = true;
	public GameObject player;
	public GameObject cam;
	public GameObject worker;
	public Texture closeBtn, menuBackground, tabBackground, tabText, confirmationBackground;
	public questionNumber[] questions;
	public GUIStyle questionFontStyle;
	public GUIStyle buttonStyle = new GUIStyle();
	
	public int vertOffset = 100;
	public int tabDuration = 200;
	
	
	private bool questions_started = false;
	private bool clicked = false;
	private int numHotSpots;
	
	private float defScreenWidth = 1920f; //The dimensions that the image was designed for
	private float defScreenHeight = 1200f;
	private float screenWidthRatio;
	private float screenHeightRatio;
	
	private int questionsLeft;
	private int rightAnswers = 0;
	private int curQuestion = -1;
	private int inputAnswer;
	private int answeredQuestions = 0;
	private bool tabUp = false;
	private int tabTicker = 0;
	private int maxQuestions = 5;
	
	private bool questionsCompleted = false;
	
	[System.Serializable]
	public class questionNumber
	{
		public string question;
		public string[] answer;
		public int rightAnswer;
		public bool isAnswered;
	}
	
	void Start()
	{
		DoubleClick2[] hSpots = GameObject.FindObjectsOfType(typeof(DoubleClick2)) as DoubleClick2[];
		numHotSpots = hSpots.Length;
		
		questionsLeft = questions.Length;
		Debug.Log("Number of questions: " + questionsLeft);
		
		NewQuestion();
	}
	
	void OnMouseDown()
	{
		if (((player.GetComponent<HealthScript>().Clicked.Count == player.GetComponent<HealthScript>().HarcHotSpots.Length) || (fullInspectionPrerequisite == false)) && (questionsCompleted == false) ) //Ensures all hot-spots have been clicked before asking questions
		{
			if(!Minimap.isLarge)
			{
				globalVars.menuUp = true;
				clicked = true;
				//globalVars.display = false;
			 	player.GetComponent<MouseLook>().isMoving = false;
				player.GetComponent<CharacterMotor>().canControl = false;
				cam.GetComponent<MouseLook>().isMoving = false;
				Screen.lockCursor = false;
			}
		}
		else 
		{
			if (questionsCompleted == false)
			{
				tabUp = true;
				tabTicker = 0;
			}
		}
	}
	
	void OnGUI()
	{
		if (clicked)
		{
			screenHeightRatio = Screen.height / defScreenHeight;
			screenWidthRatio = Screen.width / defScreenWidth;
			
			if (questions_started == false)
			{
				float xPos = (Screen.width) - (confirmationBackground.width * screenWidthRatio);
				float yPos = Screen.height - ((confirmationBackground.height * screenHeightRatio) + (vertOffset * 2) );
				
				GUI.DrawTexture(new Rect(xPos, yPos, confirmationBackground.width * screenWidthRatio, confirmationBackground.height * screenHeightRatio), confirmationBackground, ScaleMode.StretchToFill);
				if (GUI.Button(new Rect(xPos + ((confirmationBackground.width * screenWidthRatio) / 2f), yPos + ((confirmationBackground.height * screenHeightRatio) / 1.2f), 75 * screenWidthRatio, 50 * screenHeightRatio), "Yes"))
				{
					questions_started = true;
				}
				if (GUI.Button(new Rect(xPos + ((confirmationBackground.width * screenWidthRatio) / 2f) + (85 * screenWidthRatio), yPos + ((confirmationBackground.height * screenHeightRatio) / 1.2f), 75 * screenWidthRatio, 50 * screenHeightRatio), "No"))
				{
					DeClick();
				}
			}
			
			if ((answeredQuestions < maxQuestions) && (questions_started))
			{	
						
				//Debug.Log ("Height ratio: " + screenHeightRatio);
				//Debug.Log ("Width ratio: " + screenWidthRatio);
				
				float textVertOffset = 30 * screenHeightRatio;
				float textBorder = 250f * screenWidthRatio;
				float answerVertOffset = 50 * screenHeightRatio;
				float xPos = (Screen.width / 2) - (menuBackground.width * screenWidthRatio / 2);
				float yPos = Screen.height - ((menuBackground.height * screenHeightRatio) + vertOffset);
				
				
				GUI.DrawTexture(new Rect(xPos, yPos, menuBackground.width * screenWidthRatio, menuBackground.height * screenHeightRatio), menuBackground, ScaleMode.StretchToFill);
				if (GUI.Button(new Rect(xPos + (menuBackground.width - closeBtn.width) * screenWidthRatio, yPos, closeBtn.width * screenWidthRatio, closeBtn.height * screenHeightRatio), closeBtn, new GUIStyle())) // Close button
				{
					DeClick();
				}
				
				
				
					GUI.Label(new Rect(xPos + (textBorder / 2), yPos + textVertOffset, (menuBackground.width - textBorder) * screenWidthRatio, questionFontStyle.lineHeight), questions[curQuestion].question, questionFontStyle);
					for (int i = 0; i < questions[curQuestion].answer.Length; i++) // Answer buttons
					{
						if (GUI.Button(new Rect(xPos + (textBorder), yPos + answerVertOffset + (((menuBackground.height * screenHeightRatio) / 6) * (i + 1)), ((menuBackground.width * screenWidthRatio) - (textBorder * 2)), (menuBackground.height / 6) * screenHeightRatio), questions[curQuestion].answer[i], buttonStyle))
						{
							inputAnswer = i;
							
							if (inputAnswer == (questions[curQuestion].rightAnswer - 1))
							{
								rightAnswers++;
								//Debug.Log("Correct answer");
							}
							else
							{
								//Debug.Log("Wrong answer");
							}
							answeredQuestions++;
							questions[curQuestion].isAnswered = true;
							curQuestion = -1;
							NewQuestion();
						}
					}
			}
			else if ((answeredQuestions == maxQuestions) && (questions_started))
			{
				EndQuestions();				
			}
		}
		if ((tabUp == true) && (tabTicker < tabDuration))
		{
			tabTicker++;
			
			float newTabHeight = (tabBackground.height / 5) * 4; // Remedies the incorrect dimensions of the image
			GUI.DrawTexture(new Rect(Screen.width / 2 - (tabBackground.width / 2), Screen.height - newTabHeight, tabBackground.width, newTabHeight), tabBackground);
			GUI.DrawTexture(new Rect(Screen.width / 2 - (tabBackground.width / 2), Screen.height - newTabHeight, tabBackground.width, newTabHeight), tabText);
		}
		else if (tabTicker >= tabDuration)
		{
			tabUp = false;
			tabTicker = 0;
		}
	}
	
	void DeClick()
	{
		globalVars.menuUp = false;
		clicked = false;
		//globalVars.display = true;
		player.GetComponent<MouseLook>().isMoving = true;
		player.GetComponent<CharacterMotor>().canControl = true;
		cam.GetComponent<MouseLook>().isMoving = true;
		Screen.lockCursor = true;
	}
	
	void NewQuestion()
	{
		if (curQuestion == -1)
		{			
			curQuestion = Random.Range(0, questions.Length);
			if (questions[curQuestion].isAnswered == true)
			{
				curQuestion = -1;
				NewQuestion();
			}
			else
			{
				questionsLeft -= 1;
				//Debug.Log("Questions left: " + questionsLeft);
			}
		}
	}
	

	
	void EndQuestions()
	{
		Debug.Log("Number of right answers: " + rightAnswers + " out of " + maxQuestions);
		DeClick();
		questionsCompleted = true;
		globalVars.questionsComplete = true;
		
		if (rightAnswers > (maxQuestions * 0.4))
		{
			player.GetComponent<Achievements>().AddAchievement("Eco-Smart");
		}
		else if (rightAnswers <= (maxQuestions * 0.4))
		{
			player.GetComponent<Achievements>().AddAchievement("Jobless");
			worker.GetComponent<Animator>().SetBool("depressed", true);
		}
	}
}

