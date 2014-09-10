#pragma strict
//-------------------------//
//--variable declarations--//
//-------------------------//
var player:Transform;//the player that will be hearing it
var Sound:AudioSource;//the sound to be played
var maxDistance:Number=10;//max distance in which they can hear the sound
var maxVolume:Number=0.6;//max volume they can hear. 0-1

//-------------------------//
//--function declarations--//
//-------------------------//

//runs when the script first starts
function Start()
{
	Sound.loop=true;
	Sound.Play();
}

//runs every frame
function Update() 
{
	var dist=(player.position-transform.position).magnitude;
	Sound.volume=dist>maxDistance?0:(1-dist/maxDistance)*maxVolume;
}