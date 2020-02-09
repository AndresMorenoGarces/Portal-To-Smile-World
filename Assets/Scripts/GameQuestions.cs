using UnityEngine;

public class GameQuestions : MonoBehaviour
{
    private string[] generalCultureQuestions;
    private string[] generalCultureCorrectAnswer;
    private string[] generalCultureWrongAnswer;
    private string[] generalCultureWrongAnswer2;

    private void QuestionsAndAnswers()
    {
        generalCultureQuestions = new string[50]
        {
            "Who was the titan that gave wisdom to humans?", "Who is the Greek god of the underworld?", "Who is the messenger god?", "Who is the goddess of wisdom?", " What is the temperature of the boiling water?",
            "What is the city known as the big apple?", "In what city is Central park?", "What is a european country?", "What is a city of latin america?", " What is the currency of Japan? ",
            "How many planets are in our solar system?", "What is the name of the creature has only one eye?", "what of these is a star?", "What is a primary color?", " What is a fruit?",
            "Who wrote the Odyssey and the Iliad?", "What is the longest river on the planet?", "In what country did the Olympic Games originate?", "In what year did World War II end?", "Who is the author of El Ingenioso Hidalgo Don Quijote de la Mancha?", 
            "What is the largest country on the planet?", "What sport did Michael Jordan practice?", "What is the third planet in our solar system?", "What country is shaped like a boot?", " What is the currency of the United Kingdom? ",
            "How many sides does a hexagon have?", "How many colors does the rainbow have?", "In which Ukrainian city did the nuclear disaster occur?", "What is the official language of China?", "What is the name of the civilization that built the pyramids of giza ",
            "What planet is known as the red planet?", "What is the largest planet in the solar system?", "What scientist proposed the three laws of motion?", "What is the name of the religion that consider Coran as his book? sacred? "," What is the most populous country in the world today? ",
            "What is the largest animal on the planet?", "How many stars does the flag of the United States have?", "The platypus is?", "Who won the 2014 FIFA World Cup Brazil?", "In what city is it located The White House of the United State?",
            "Where did the first atomic bombs in combat fall?", "What is the name of Portugal capital? ", "In what country does the so-called encyclopedia originate during the enlightenment?", "In which country is the Christ redeemer? "," What is the fastest land animal? ",
            "In Norse mythology, who is Thor's father?", "What was Disney's first animated film?", "What is the city with the largest population on the planet?", "What is the name of the branch of biology who study plants? "," In which country is St. Peter's Basilica? ",
        };
        generalCultureCorrectAnswer = new string[50]
        {
            "Prometheus", "Hades", "Hermes", "Athena", "100 degrees Celsius",
            "New York", "New York", "Romania", "Buenos Aires", "Yen",
            "9", "Cyclops", "Sun", "Yellow", "Avocado",
            "Homer", "Amazon", "Greece", "1945", "Miguel de servantes saavedra",
            "Russia", "Basketball", "The Earth", "Italy", "Pound",
            "6", "7", "Pripiat", "Mandarin", "Egyptians",
            "Mars", "Jupiter", "Newton", "Islam", "China",
            "Blue Whale", "50", "Mammal", "Germany", "Washington DC",
            "Japan", "Lisbon", "France", "Brazil", "Cheetah",
            "Odin", "Snow White", "Tokyo", "Botany", "Vatican City",
        };
        generalCultureWrongAnswer = new string[50]
        {
            "Chronos", "Helios", "Helios", "Era", "150 degrees Celsius",
            "Paris", "Las Vegas", "New Zeland", "Canberra", "Euro",
            "10", "Licantropo", "Andromeda", "Green", "Lettuce",
            "Aristoteles", "Nilo", "Germany", "1943", "Gabriel Garcia Marquez",
            "China", "Volleyball", "Venus", "France", "Euro",
            "7", "6", "Kiev", "English", "Mayas",
            "Jupiter", "Saturn", "Einstein", "Christian", "Russia",
            "Elephant", "40", "Fish", "Argentina", "New York",
            "United States", "Verona", "Spain", "Colombia", "Tigre",
            "Loky", "Cinderella", "New York", "Cellular biology", "Spain",
        };
        generalCultureWrongAnswer2 = new string[50]
        {
            "Atlas", "Poseidon", "Athena", "Aphrodite", "200 degrees Celsius",
             "London", "Washington", "Morocco", "Munich", "Franco",
             "8", "Leprechaun", "Mars", "Orange", "Carrot",
             "Platon", "Geneva", "England", "1946", "Edgar Allan Poe",
             "United States", "Soccer", "Mars", "England", "Dollar",
             "10", "8", "Odessa", "Korean", "Aztecs",
             "Saturn", "Pluto", "Darwin", "Buddhist", "United States",
             "White shark", "45", "Reptile", "France", "Las Vegas",
             "Germany", "Porto", "England", "Argentina", "Leon",
             "Freya", "Beauty and the beast", "Moscow", "Developmental biology", "Germany"
        };
    }
    public void SendGeneralCQuestionsValues(string[] _generalCultureQuestions)
    {
        generalCultureQuestions = _generalCultureQuestions;
    }
    public void SendGeneralCAnswersValues(string[] _generalCultureCorrectAnswer, string[] _generalCultureWrongAnswer, string[] _generalCultureWrongAnswer2)
    {
        generalCultureCorrectAnswer = _generalCultureCorrectAnswer;
        generalCultureWrongAnswer = _generalCultureWrongAnswer;
        generalCultureWrongAnswer2 = _generalCultureWrongAnswer2;
    }

    private void Start()
    {
        QuestionsAndAnswers();
    }
}
