using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {cell, sheets_0, sheets_1, mirror, cell_mirror, lock_0, lock_1, escape, corridor_0, 
						stairs_0, floor, closet_door, stairs_1, corridor_1, in_closet, stairs_2, corridor_2, 
						courtyard, corridor_3};
	private States currentState;
	
	int counter;

	// Use this for initialization
	void Start () {
		currentState = States.cell;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		switch (currentState)	{
			
			case States.cell:
				cell();
				break;
			
			case States.sheets_0:
				sheets_0();
				break;
				
			case States.sheets_1:
				sheets_1();
				break;
				
			case States.mirror:
				mirror();			
				break;
				
			case States.cell_mirror:
				cell_mirror();				
				break;
				
			case States.lock_0:
				lock_0();		
				break;
				
			case States.lock_1:
				lock_1();	
				break;
				
			case States.escape:
				escape_cell();	
				break;
			
			case States.corridor_0:
				corridor_0();	
				break;
			
			case States.stairs_0:
				stairs_0();
				break;
			
			case States.floor:
				floor();
				break;
			
			case States.closet_door:
				closet_door();
				break;
			
			case States.stairs_1:
				stairs_1();
				break;
			
			case States.corridor_1:
				corridor_1();
				break;
			
			case States.in_closet:
				in_closet();
				break;
			
			case States.stairs_2:
				stairs_2();
				break;
				
			case States.corridor_2:
				corridor_2();	
				break;
				
			case States.courtyard:
				courtyard();
				break;			
				
			case States.corridor_3:
				corridor_3();
				break;
					
			default:
				break; 
						
		} 	
		
	}
	
	void cell()	{
		text.text = "You are a prisoner who is stuck in a cell." + "There are sheets on the bed," + 
					" a mirror on the wall" + " and a lock on the door that you need to open to get out.\n" +
					"Press S to examine the sheets.\n" + "Press L to examine the lock.\n" + 
					"Press M to examine the mirror.\n";
		if(Input.GetKeyDown(KeyCode.S))	{
			currentState = States.sheets_0;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.M))	{
			currentState = States.mirror;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.L))	{
			currentState = States.lock_0;
			counter++;
		}
	}
	
	void sheets_0()	{
		text.text = "These sheets appear to be of poor quality.\nPress R to stop examining the sheets.";
		if(Input.GetKeyDown(KeyCode.R))	{
			currentState = States.cell;
			counter++;
		}
	}
	
	void sheets_1()	{
		text.text = "These sheets already have quite a few holes in them, there isn't anything left" +
					" for you to tear with a mirror.\nPress R to stop examining the sheets.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.cell_mirror;
			counter++;
		}
	}
	
	void cell_mirror()	{
		text.text = "Press S to try using the mirror on the sheets.\n" +
					"Press L to try using the mirror on the lock.";
		if (Input.GetKeyDown(KeyCode.S))	{
			currentState = States.sheets_1;
			counter++;
		}
		if (Input.GetKeyDown(KeyCode.L))	{
			currentState = States.lock_1;
			counter++;
		}
	}
	
	void mirror()	{
		text.text = "The mirror has sharp edges.\nPress T to take the mirror.\nPress R to stop examining the mirror.";
		if (Input.GetKeyDown(KeyCode.T))	{
			currentState = States.cell_mirror;
			counter++;
		}
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.cell;
			counter++;
		}
	}
	
	void lock_0()	{
		text.text = "This lock seems to be quite old. It could be opened with a sharp object.\n" + 
					"Press R to stop examining the lock.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.cell;
			counter++;
		}
	}
	
	void lock_1()	{
		text.text = "This lock seems to be quite old. It could be opened with a sharp object.\n" +
					"Press R to stop examining the lock.\nPress O to use the mirror on the lock.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.cell_mirror;
			counter++;
		}
		if (Input.GetKeyDown(KeyCode.O))	{
			currentState = States.escape;
			counter++;
		}
	}
	
	void escape_cell()	{
		currentState = States.corridor_0;
	}
	
	void corridor_0()	{
		text.text = "You have entered the hallway. You see a flight of stairs, a dirty floor" + 
					" and a door to the closet\nPress S to go up the stairs.\nPress F to examine the floor.\n" + 
					"Press C to enter the closet.";
		if(Input.GetKeyDown(KeyCode.S))	{
			currentState = States.stairs_0;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.F))	{
			currentState = States.floor;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.C))	{
			currentState = States.closet_door;
			counter++;
		}
	}
	
	void stairs_0()	{
		text.text = "You cannot go out looking like a prisoner.\nPress R to return to the hallway.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.corridor_0;
			counter++;
		}
	}
	
	void floor()	{
		text.text = "This floor seems to be quite dusty. This place could really use a janitor." +
					"There appears to be a rusty hairpin lying on the floor.\nPress T to take it" +
					"\nPress R to stop inspecting the floor.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.corridor_0;
			counter++;
		}
		if (Input.GetKeyDown(KeyCode.T))	{
			currentState = States.corridor_1;
			counter++;
		}
	}
	
	void closet_door()	{
		text.text = "The door is locked. I wonder how you opened a locked door last time.\n" + 
					"Press R to return to the hallway.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.corridor_0;
			counter++;
		}
	}
	
	void corridor_1()	{
		text.text = "Press S to go up the stairs, this time with a hairpin (the perfect disguise).\n" + 
					"Press C to use the hairpin on the closet door.";
		if(Input.GetKeyDown(KeyCode.S))	{
			currentState = States.stairs_1;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.C))	{
			currentState = States.in_closet;
			counter++;
		}
	}
	
	void stairs_1()	{
		text.text = "The hairpin makes no difference, who do you think you are? Clark Kent? Get outta here!\n" +  
					"Press R to return to the hallway.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.corridor_1;
			counter++;
		}
	}
	
	void in_closet()	{
		text.text = "You managed to open the closet door. There appears to be a janitor uniform in it.\n" + 
					"Press P to put on the janitor uniform.\nPress R to ignore the uniform.";
		if(Input.GetKeyDown(KeyCode.P))	{
			currentState = States.corridor_3;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.R))	{
			currentState = States.corridor_2;
			counter++;
		}
	}
	
	void corridor_2()	{
		text.text = "Press S to go up the stairs, once again with a hairpin...you can't take a hint can you?\n" + 
					"Press C to inspect the closet once again.";
		if(Input.GetKeyDown(KeyCode.S))	{
			currentState = States.stairs_2;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.C))	{
			currentState = States.in_closet;
			counter++;
		}
	}
	
	void stairs_2()	{
		text.text = "Just no.\nPress R to return to the hallway.";
		if (Input.GetKeyDown(KeyCode.R))	{
			currentState = States.corridor_2;
			counter++;
		}
	}
	
	void corridor_3()	{
		text.text = "Press S to go up the stairs as a janitor.\nPress U to take off the janitor uniform";
		if(Input.GetKeyDown(KeyCode.S))	{
			currentState = States.courtyard;
			counter++;
		}
		if(Input.GetKeyDown(KeyCode.C))	{
			currentState = States.in_closet;
			counter++;
		}
	}
	
	void courtyard()	{
		text.text = "No one's none the wiser about your disguise, you're scot free!\n" +
					"You beat the game in " + counter + " moves. Thanks for playing.\n" + 
					"Press R to replay the game, to perhaps, win in fewer moves.\nP.S-The lowest no of moves " +
					"you can beat the game in is 9.";
		if(Input.GetKeyDown(KeyCode.R))
			currentState = States.cell;
	}
	
}
