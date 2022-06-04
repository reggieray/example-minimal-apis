// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "Example code")]
[assembly: SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = "Example code", Scope = "type", Target = "~T:TodoItem")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Example code", Scope = "member", Target = "~M:TodoItemDTO.#ctor(TodoItem)")]
[assembly: SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification = "Example code", Scope = "type", Target = "~T:TodoItemDTO")]
