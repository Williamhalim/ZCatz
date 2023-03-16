using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandomTrivia : MonoBehaviour {

	public Text displayWord;
	int rand;

	public string[] randomTrivia = new string[]{
		"Stroking a cat can help to relieve stress, and the feel of a purring cat on your lap conveys a strong sense of security and comfort.",
		"The cat's tail is used to maintain balance.",
		"Cats eat grass to aid their digestion and to help them get rid of any fur in their stomachs.",
		"When a cats rubs up against you, the cat is marking you with it's scent claiming ownership.",
		"The average lifespan of an outdoor-only cat is about 3 to 5 years while an indoor-only cat can live 16 years or much longer.",
		"Cats have the largest eyes of any mammal.",
		"Milk can give some cats diarrhea.",
		"On average, a cat will sleep for 16 hours a day.",
		"The life expectancy of cats has nearly doubled over the last fifty years.",
		"Cats have existed longer than humans.",
		"Cats can jump 5 times their height.",
		"Normally, cats have 12 whiskers on each side of their nose.",
		"The biggest cat species today is the Siberian Tiger. It can be more than 3.6 m long (about the size of a small car) and weigh up to 317 kg.",
		"On average, cats spend 2/3 of the day sleeping. That means a 9 year-old cat has been awake for only three years of its life.",
		"The smallest pedigreed cat is a Singapura, which can weigh just 4 lbs (1.8 kg), or about five large cans of cat food.",
		"Cats hate the water because their fur does not insulate well when it’s wet.",
		"A cat almost never meows at another cat, mostly just humans. Cats typically will spit, purr, and hiss at other cats.",
		"The richest cat is Blackie who was left £15 million by his owner, Ben Rea.",
		"\"Jay\" used to be slang for \"foolish person.\" So when a pedestrian ignored street signs, he was referred to as a \"jaywalker.\"",
		"Alaska is the only state in the US that can be typed on one row of keys.",
		"Horses can't vomit.",
		"The most used letter in English dictionary is \"e\", while the least used is \"z\".",


		"TIPS: Try equipping spells if you are having difficulty fighting a multiple number of catz.",
		"TIPS: Catz that attacks faster are the squishier ones.",


	};


	// Use this for initialization
	void Start () {
		rand = Random.Range (0, randomTrivia.Length);
		displayWord.text = randomTrivia [rand];

	}

}
