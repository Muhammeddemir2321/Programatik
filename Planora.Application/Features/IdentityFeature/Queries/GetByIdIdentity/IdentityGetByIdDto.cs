﻿namespace Planora.Application.Features.IdentityFeature.Queries.GetByIdIdentity;

public class IdentityGetByIdDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}
