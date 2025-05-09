namespace Core.CrossCuttingConcerns.Constants;
public static class ErrorConstants
{
    public const string UserNameAlreadyExists = "error.email_already_exists";
    public const string UserNotFound = "error.user_not_found";
    public const string UserNameAlreadyTaken = "error.username_already_taken";
    public const string RequestedRecordDoesNotExist = "error.requested_record_does_not_exist";
    public const string UsernameOrPasswordIsWrong = "error.username_or_password_is_wrong";
    public const string YouAreNotAuthorized = "error.you_are_not_authorized";
    public const string PasswordsDoesNotMatch = "error.passwords_does_not_match";
    public const string IsNullOrEmpty = "error.is_null_or_empty";
    public const string PleaseGeneratePassword = "error.please_generate_password";
    public const string ClaimNotFound = "error.claim_not_found";
    public const string TokenOptionsNotReadable = "error.token_options_not_readable";
    public const string UserNotCreatedBecauseIdentityNotCreated = "error.user_not_created_because_identity_not_created";
    public const string FirstNameMustNotBeEmpty = "error.first_name_must_not_be_empty";
    public const string LastNameMustNotBeEmpty = "error.last_name_must_not_be_empty";
    public const string UserNameMustBeEmailFormat = "error.user_name_must_be_email_format";
    public const string EmailHasBeenSentCannotMakeChanges = "error.email_has_been_sent_cannot_make_changes";
    public const string NameAlreadyTaken = "error.name_already_taken";
    public const string UserTypeNotDetected = "error.user_type_not_detected";
    public const string UserHasActiveVerificationCode = "error.user_has_active_verification_code";
    public const string AddressMustNotBeEmpty = "error.address_must_not_be_empty";
    public const string NameMustNotBeEmpty = "error.name_must_not_be_empty";
    public const string PhoneNumberMustNotBeEmpty = "error.phone_number_must_not_be_empty";
    public const string GuaranteePeriodMustNotBeEmpty = "error.guarantee_period_must_not_be_empty";
    public const string RefreshTokenIsExpired = "error.refresh_token_is_expired";
    public const string RefreshTokenIsRevoked = "error.refresh_token_is_revoked";
    public const string PasswordMustNotBeEmpty = "error.password_must_not_be_empty";
}
