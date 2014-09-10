function Start(){

yield WaitForSeconds(2);
//Debug.Log("Loading Scene");
Resources.UnloadUnusedAssets();
Application.LoadLevel("ResourceEmpty");
//yield WaitForSeconds (10);
//Debug.Log("Scene Loaded");
//Application.LoadLevel("ResourceEmpty");

}