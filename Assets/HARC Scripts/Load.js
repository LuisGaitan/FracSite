var percentageLoaded : float = 0;

function Update() 
{ 
    if(Application.CanStreamedLevelBeLoaded(3)||Application.GetStreamProgressForLevel(3) == 2) 
    { 
        Application.LoadLevel(3);
    } else 
    {
        percentageLoaded = Application.GetStreamProgressForLevel(2) * 100;
    }
}

function OnGUI()
{
	GUI.Box(Rect((Screen.width-400)/2,(Screen.height-50)/2,400,50),"\nLoading : "+percentageLoaded);
}
