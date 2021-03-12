using MediatR;

namespace BizBloqz.Application.Text.Commands
{
    public class CreateTextCommand : IRequest<bool>
    {
        public string TextValue { get; private set; }
        public CreateTextCommand(string textValue)
        {
            TextValue = textValue;
        }
    }
}
