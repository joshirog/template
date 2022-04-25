using FluentValidation;
using FluentValidation.Validators;

namespace Monkeylab.Templates.Application.Commons.Validator
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> MatchAlphaNumericShort<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator<T>("^[a-zA-Z0-9_-]*$"));
        }
        public static IRuleBuilderOptions<T, string> MatchAlphaNumericExtended<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator<T>("^[a-zA-Z0-9,. _'&!/()*+:?-]*$"));
        }
        public static IRuleBuilderOptions<T, string> MatchNumericRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator<T>("^[0-9]*$"));
        }
    }
}