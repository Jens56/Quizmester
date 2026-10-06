using System;

namespace APPR___Quizmester___91780
{
    internal class Question
    {
        int questionId = -1;
        string question = "";
        string correctAnswer = "";
        string falseAnswerOne = "";
        string falseAnswerTwo = "";
        string falseAnswerThree = "";
        string questionType = "";

        public Question(int c_questionId, string c_question, string c_correctAnswer,
                         string c_falseAnswerOne, string c_falseAnswerTwo, string c_falseAnswerThree,
                         string c_questionType)
        {
            questionId = c_questionId;
            question = c_question;
            correctAnswer = c_correctAnswer;
            falseAnswerOne = c_falseAnswerOne;
            falseAnswerTwo = c_falseAnswerTwo;
            falseAnswerThree = c_falseAnswerThree;
            questionType = c_questionType;
        }

        public int GetQuestionId()
        {
            return questionId;
        }

        public string GetQuestion()
        {
            return question;
        }

        public string GetCorrectAnswer()
        {
            return correctAnswer;
        }

        public string GetFalseAnswerOne()
        {
            return falseAnswerOne;
        }

        public string GetFalseAnswerTwo()
        {
            return falseAnswerTwo;
        }

        public string GetFalseAnswerThree()
        {
            return falseAnswerThree;
        }

        public string GetQuestionType()
        {
            return questionType;
        }
    }
}