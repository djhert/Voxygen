using UnityEngine;

public static class Math {
	
	public const int Max = 2147483647;
	
	public static float square( int num ) {
		return (float)(num*num);
	}
	
	public static float cube( int num ) {
		return (float)(num*num*num);
	}
	
	public static int round( float num ) {
		return (int)num;
	}
	
	public static bool flipCoin() {
		if( (Random.Range(0,20)%2) == 1 )
			return true;
		else
			return false;
	}
	
	public static int random() {
		return Random.Range( 1 , Max );
	}
	
	public static int random( int min, int max ) {
		return Random.Range(min,(max+1)); 
	}
	
	public static float randomf( float min, float max ) {
		return Random.Range(min,max); 
	}
	
	public static int randThree() {
		return (Random.Range(1,30)%3)+1;
	}
	
	public static int randFour() { 
		return (Random.Range(1,40)%4)+1;
	}
	
	public static int randFive() { 
		return (Random.Range(1,50)%5)+1;
	}
	
	public static int genSix() {
		return (Random.Range(1,60)%6)+1;
	}
	
	public static int randHundred() {
		return (Random.Range(1,101) );
	}
	
	public static int Percent( float percent ) {
		return (int)(percent*100);
	}
	
	public static int mod(int input,int amount){
		return (input%amount)+1;
	}

	public static int multiPercent(int input, float num) {
		return(int)(input*num);
	}
	
	public static bool numBetween(int num, int bottom, int top) {
		if( num > bottom && num < top )
			return true;
		else
			return false;
	}

	public static int sqrt(int num){
		return (int)Mathf.Sqrt(num);
	}
}
