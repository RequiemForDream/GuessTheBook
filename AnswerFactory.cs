using Answers;
using Factories.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class AnswerFactory : IFactory<Answer>
    {
        private readonly AnswerConfigs _answerConfigs;

        public AnswerFactory(AnswerConfigs answerConfigs)
        {
            _answerConfigs = answerConfigs;
        }

        public Answer Create()
        {    
            AnswerView answerView = Object.Instantiate(_answerConfigs.AnswerConfiguration.AnswerView);

            Answer answer = new Answer(answerView, _answerConfigs.AnswerConfiguration.AnswerModel);

            return answer;
        }
    }
}
