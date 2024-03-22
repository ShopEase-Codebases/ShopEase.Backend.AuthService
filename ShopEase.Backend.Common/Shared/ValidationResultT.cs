﻿namespace ShopEase.Backend.Common.Shared
{
    public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        private ValidationResult(Error[] errors)
            : base(default, false, IValidationResult.ValidationError) =>
            Errors = errors;

        public Error[] Errors { get; }

        public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);

        public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onSuccess, Func<Error[], TNextValue> onError)
        {
            if (IsSuccess)
            {
                return onSuccess(Value);
            }

            return onError(Errors);
        }
    }
}
