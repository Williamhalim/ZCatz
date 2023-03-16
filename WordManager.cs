using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WordManager : MonoBehaviour {

	public static GameObject victoryScreen;
	public GameObject victoryScreen_;

	public static GameObject keyboardCanvas;
	public GameObject keyboardCanvas_;

	public static Text spoils1;
	public static Text spoils2;
	public static Text spoils3;

	public Text spoils1_;
	public Text spoils2_;
	public Text spoils3_;


	public static string lockedOnWord;
	public static string lockedOnWord2;
	public static string lockedOnWord3;
	public static string lockedOnWord4;


	public static int enemyAmount;
	//public static GameObject typingS;


	public static Text[] text = new Text[4];
	public static Enemy[] enemyS = new Enemy[4];
	public static EnemyShake[] enemyShake = new EnemyShake[3];
	public static Typing typing;


	void Awake (){

		victoryScreen = victoryScreen_;
		keyboardCanvas = keyboardCanvas_;
		spoils1 = spoils1_;
		spoils2 = spoils2_;
		spoils3 = spoils3_;

		Typing.wordManager = this;

	}

	public static string[] wordLevel1 = new string[]{
		"by","no","so","as","in","an","pi","do","to","go","me","my","on","is","he","up","if","yo",
		"cry","tie","pie","buy","log","fog","tub","lie","fit","log","bad","hat","jaw","van","ent",
		"tad","mad","lad","mat","pat","pet","bed","pot","lot","pay","may","die","mop","eco","end",
		"yew","new","jew","gun","bun","fun","tan","gem","hot","cog","tag","ban","how","oil","kid",
		"way","fly","out","see","low","day","all","say","the","hex","mew","man","fan","joe","cue",
		"ray","bay","dye","sky","got","hit","say","pie","set","cut","bok","pok","tak","mak","zed",
		"abs","act","ace","add","ado","aft","age","ago","aid","ail","aim","air","ale","all","amp",
		"and","ant","ape","apt","arc","are","ark","arm","art","ash","ask","ate","awe","axe","bad",
		"bag","bad","ban","bam","bar","bat","bay","bed","bee","beg","bet","bey","bid","big","bin",
		"bio","cab","can","cap","cam","cat","kat","cee","cha","cod","cow","coy","dam","day","dew",
		"die","dog","dry","due","duo","dye","ear","eat","ell","elk","ego","elf","egg","elm","emo",
		"emu","eon","era","eve","eye","far","fat","fed","fee","few","fix","fly","foe","fun","fur",
		"gap","gas","gel","gin","get","git","got","gun","gym","hey","hen","her","hex","hid","hoe",
		"hog","how","hue","ice","icy","imp","ill","inn","ion","ire","jaw","jem","jet","keg","key",
		"tea","leg","let","lie","lit","low","men","nee","neo","net","new","now","ode","one","ore",
		"owe","owl","own","pad","pan","paw","pax","pea","pee","peg","pen","pep","pet","pew","pie",
		"rye","rue","roe","red","set","sew","she","see","sec","sob","sky","sun","spa","sue","tax",
		"tie","toe","two","urn","use","vex","vet","wet","yet","yew","zoo","yep","yes","zen","zoa",
		"moa","bob","jon","mac","pig","pic","lob","toy","joy","roy","soy","boy","any","you","yon",
		"leo","maw","mow","mew","miu","min","max","mak","mac","fit","fed","fin","cup","don","all",

		"ukh","akh","ekh","arg","urg","aow","pow","bzt","yea","tin",





	};
	public static string[] wordLevel2 = new string[]{
		"leek","leak","meek","peek","peak","hold","told","gold","mold","sold","jolt",
		"take","good","only","hour","year","gone",
		"frog","pond","jump","land","blue","bloo","rock","toss","loss","lost","high",
		"jolt","bolt","fold","trap","long","fang","tree","free","gate","life","time",
		"hire","mine","leaf","troy","bear","look","turn","fall","feel","felt","past",
		"sail","view","need","seed","wind","hair","many","lost","solo","stay","burn",
		"eyes","fire","rain","deep","fear","pain","half","body","left","maze","hell",
		"free","mind","find","once","more","king","here","fate","know","cold","much",

	};

	public static string[] wordLevel3 = new string[]{
		"alive","ready","write","story","found","eagle","stand","drift","above","climb",
		"heart","veins","break","chain","black","fight","blaze","craze","dream","chaos",

	};

	public static string[] wordLevel5 = new string[]{
		"atonal","harmony","counter","strings","integer","variety","unison","octave","rosetta","solomon","retina","rasgueado","flamenco","aeternum",
		"aeolian","messiah","granite","etesian","phrygian","lydian","locrian","knossos","unleash","electrode","adhesion","rumba","rhetoric","vehementi",
		"arcane","alkane","amplify","atomic","friction","bionics","buoyant","gravity","concave","kinetic","photon","quarks","antimatter","arafuru",
		"quanta","reagent","solvent","chromatic","fission","inertia","polychord","diminished","augmented","altered","osmosis","arpeggio","oratorio",
		"robonaut","battuta","niente","acoustic","anacrusis","antiphon","stanza","quatrain","iambic","ellipsis","crescendo","draconian",
		"organum","ostinato","cancer","jupiter","saturn","sagittarius","aquarius","condensed","trophaic","spondaic","sporadic","myrmidon",
		"anapestic","dactylic","hexameter","pentameter","syncopation","inversion","substitute","diatonic","melodic","harmonic","nomadic","magica","arcadia",
		"neapolitan","plagal","cadence","gemini","apollo","deadlock","reverb","filter","substring","detache","legato","staccato","sasquatch",
		"mezzoforte","decibel","algorithm","rhythm","amygdala","thallamus","archetype","antinomy","paradox","parallel","axiom","atlantis","lindenbaum",
		"dialectic","dualism","idealism","minimalist","baroque","harpsichord","nihilism","pantheon","solipsism","catharsis","vivace","rifenia","enchantra",
		"gestalt","pluralism","quadruple","compound","woodwind","orchestra","percussion","symphony","fairytale","chyrastra",
		"tritone","hemiola","semibreve","ionian","mystica","vernacula","biomass","carbonate","hydrogen","nucleolus","iryllica","baalzebul",
		"genotype","phenotype","phloem","xylem","xylophone","zygote","phagotti","bassoon","oboe","exurbia","bifurcate","submediant","pilato",
		"zeitgeist","dissonant","consonant","transient","modulate","ephemeral","ethereal","elysium","capulet","allegory","oberon","brillig",
		"titania","yliaster","sephiroth","thoth","undine","cybele","sibelius","atavaka","sarasvati","anjali","siegfried","taestoli","exodus",
		"nibelung","yurlungur","apsaras","jatayu","metatron","trombone","euphonium","dystopia","utopia","paragon","syllable","vorpal","passus",
		"cardioid","phosphorus","apparation","lunacia","ricercata","waltz","valse","brillante","quartet","quintet","septet","sextet","minuette","akkadia",
		"gavotte","sarabande","allamande","bouree","prelude","overture","sonata","concerto","sumeria","isometric","tempest","carthage","achilles","ecclesia",
		"paganini","campanella","ramayana","bebop","genesis","crotchet","quaver","semicolon","adagio","andante","allegro","quaternion",
		"amadeus","armamite","hautbois","cimbasso","cimarosa","dutilleux","sultasto","rebirth","incarnate","mindanao","aetheria","chronos","supernova",
	};

	public static string[] wordLevel6 = new string[]{
		"fauxbordon","everfloriss","emfindsamkeit","adiabatic","counterpoint","subdominant","mendelssohn","schenkerian","subconscious","semiquaver",
		"parametric",
	};



	public void PrintLocked4(){
		print (lockedOnWord4);
	}



	public static void MatchWord(){
		for(int i = 0; i < 4; i++) {
			if (text [i] != null && text [i].text.Substring (0, 1) == Typing.letters.Substring (0, 1)) {
				lockedOnWord = text [i].text;
			}
			if (Typing.letters.Length == 2 && text [i] != null && text [i].text.Substring (1, 1) == Typing.letters.Substring (1, 1)) {
				lockedOnWord2 = text [i].text;
			}
			if (Typing.letters.Length == 3 && text [i] != null && text [i].text.Substring (2, 1) == Typing.letters.Substring (2, 1)) {
				lockedOnWord3 = text [i].text;
			}
			if (Typing.letters.Length >= 4 && text [i] != null && text [i].text.Substring (3, 1) == Typing.letters.Substring (3, 1)
				|| Typing.letters.Length == 1 && text [i] != null && text [i].text.Substring (0, 1) == Typing.letters.Substring (0, 1)
			) {
				lockedOnWord4 = text [i].text;
			}
		}
	}

	//"type" is a variable used to store the "letters" from the script "Typing". >> refer to public void PrintLetters(){}
	public static void EnterWord(string type){
		for (int i = 0; i < 4; i++) {
			if (text [i] != null && text [i].text == type) {
			enemyS [i].ChangeWord ();
			enemyS [i].Damage ();
			typing.DamageSFX ();
		}
		else {
			typing.ClearText();
		}
			if (enemyAmount == 0) {
				victoryScreen.SetActive (true);
				keyboardCanvas.SetActive (false);
				FreezeTime.freez = false;
			}
	}
	}

	void Update(){

	}
}
