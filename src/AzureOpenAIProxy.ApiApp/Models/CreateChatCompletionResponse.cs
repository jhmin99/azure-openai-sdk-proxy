using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using AzureOpenAIProxy.ApiApp.Converters;

namespace AzureOpenAIProxy.ApiApp.Models;

/// <remark>
/// The response from creating a chat completion.
/// For more information, see <a href="https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cognitiveservices/data-plane/AzureOpenAI/inference/stable/2024-06-01/inference.json">azure-rest-api-specs(2024-06-01)</a>
/// </remark>
public class CreateChatCompletionResponse
{
    /// <summary>
    /// Gets or sets a unique identifier for the chat completion. 
    /// </summary>
    [JsonPropertyName("id"), Required]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the object type.
    /// </summary>
    [JsonPropertyName("object"), Required]
    public ChatCompletionResponseObject? Object { get; set; }

    /// <summary>
    /// Gets or sets the Unix timestamp (in seconds) of when the chat completion was created.
    /// </summary>
    [JsonPropertyName("created"), Required]
    public long? Created { get; set; }

    /// <summary>
    /// Gets or sets the model used for the chat completion.
    /// </summary>
    [JsonPropertyName("model"), Required]
    public string? Model { get; set; }

    /// <summary>
    /// Gets or sets usage statistics for the completion request.
    /// </summary>
    [JsonPropertyName("usage")]
    public CompletionUsage? Usage { get; set; }

    /// <summary>
    /// Gets or sets the system fingerprint. 
    /// Can be used in conjunction with the `seed` request parameter to understand when backend changes have been made that might impact determinism.
    /// </summary>
    [JsonPropertyName("system_fingerprint")]
    public string? SystemFingerprint { get; set; }

    /// <summary>
    /// Gets or sets content filtering results for zero or more prompts in the request. 
    /// In a streaming request, results for different prompts may arrive at different times or in different orders.
    /// </summary>
    [JsonPropertyName("prompt_filter_results")]
    public List<PromptFilterResult>? PromptFilterResults { get; set; }

    /// <summary>
    /// Gets or sets a list of choices.
    /// </summary>
    [JsonPropertyName("choices"), Required]
    public List<ChatCompletionChoice>? Choices { get; set; }
}

/// <summary>
/// Represents a choice in the chat completion response.
/// </summary>
public class ChatCompletionChoice
{
    /// <summary>
    /// Gets or sets an index.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    /// Gets or sets the finish reason.
    /// </summary>
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }

    /// <summary>
    /// Gets or sets a chat completion message generated by the model.
    /// </summary>
    [JsonPropertyName("message")]
    public ChatCompletionResponseMessage? Message { get; set; }

    /// <summary>
    /// Information about the content filtering category (hate, sexual, violence, self_harm), if it has been detected, as well as the severity level (very_low, low, medium, high-scale that determines the intensity and risk level of harmful content) and if it has been filtered or not. Information about third party text and profanity, if it has been detected, and if it has been filtered or not. And information about customer block list, if it has been filtered and its id.
    /// </summary>
    [JsonPropertyName("content_filter_results")]
    public ContentFilterChoiceResults? ContentFilterResults { get; set; }

    /// <summary>
    /// Gets or sets log probability information for the choice.
    /// </summary>
    [JsonPropertyName("logprobs")]
    public ChatCompletionChoiceLogProbs? LogProbs { get; set; }
}

/// <summary>
/// A chat completion message generated by the model.
/// </summary>
public class ChatCompletionResponseMessage
{
    /// <summary>
    /// Gets or sets the role of the author of the response message.
    /// </summary>
    [JsonPropertyName("role")]
    public ChatCompletionResponseMessageRole? Role { get; set; }

    /// <summary>
    /// Gets or sets the contents of the message.
    /// </summary>
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the tool calls generated by the model, such as function calls.
    /// </summary>
    [JsonPropertyName("tool_calls")]
    public List<ChatCompletionMessageToolCall>? ToolCalls { get; set; }

    /// <summary>
    /// Gets or sets the function call
    /// Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model.
    /// </summary>
    [JsonPropertyName("function_call")]
    public ChatCompletionFunctionCall? FunctionCall { get; set; }

    /// <summary>
    /// Gets or sets a representation of the additional context information available when Azure OpenAI chat extensions are involved in the generation of a corresponding chat completions response. 
    /// This context information is only populated when using an Azure OpenAI request configured to use a matching extension.
    /// </summary>
    [JsonPropertyName("context")]
    public AzureChatExtensionsMessageContext? Context { get; set; }
}

/// <summary>
/// Information about the content filtering category (hate, sexual, violence, self_harm), if it has been detected, 
/// as well as the severity level (very_low, low, medium, high-scale that determines the intensity and risk level of harmful content) 
/// and if it has been filtered or not. Information about third-party text and profanity, if it has been detected, and if it has been filtered or not. 
/// Also includes information about the customer block list, if it has been filtered and its ID.
/// </summary>
public class ContentFilterChoiceResults
{
    /// <summary>
    /// Gets or sets the severity result for sexual content.
    /// </summary>
    [JsonPropertyName("sexual")]
    public ContentFilterSeverityResult? Sexual { get; set; }

    /// <summary>
    /// Gets or sets the severity result for violent content.
    /// </summary>
    [JsonPropertyName("violence")]
    public ContentFilterSeverityResult? Violence { get; set; }

    /// <summary>
    /// Gets or sets the severity result for hateful content.
    /// </summary>
    [JsonPropertyName("hate")]
    public ContentFilterSeverityResult? Hate { get; set; }

    /// <summary>
    /// Gets or sets the severity result for self-harm content.
    /// </summary>
    [JsonPropertyName("self_harm")]
    public ContentFilterSeverityResult? SelfHarm { get; set; }

    /// <summary>
    /// Gets or sets the detected result for profane content.
    /// </summary>
    [JsonPropertyName("profanity")]
    public ContentFilterDetectedResult? Profanity { get; set; }

    /// <summary>
    /// Gets or sets error details for content filtering.
    /// </summary>
    [JsonPropertyName("error")]
    public ErrorBase? Error { get; set; }

    /// <summary>
    /// Gets or sets the detected result for protected material in text.
    /// </summary>
    [JsonPropertyName("protected_material_text")]
    public ContentFilterDetectedResult? ProtectedMaterialText { get; set; }

    /// <summary>
    /// Gets or sets the detected result for protected material in code, including citation information.
    /// </summary>
    [JsonPropertyName("protected_material_code")]
    public ContentFilterDetectedWithCitationResult? ProtectedMaterialCode { get; set; }
}

/// <summary>
/// Log probability information for the choice.
/// </summary>
public class ChatCompletionChoiceLogProbs
{
    /// <summary>
    /// Gets or sets a list of message content tokens with log probability information.
    /// </summary>
    [JsonPropertyName("content"), Required]
    public List<ChatCompletionTokenLogProb>? Content { get; set; }
}

/// <summary>
/// Usage statistics for the completion request.
/// </summary>
public class CompletionUsage
{
    /// <summary>
    /// Gets or sets number of tokens in the prompt.
    /// </summary>
    [JsonPropertyName("prompt_tokens"), Required]
    public int? PromptTokens { get; set; }

    /// <summary>
    /// Gets or sets number of tokens in the generated completion.
    /// </summary>
    [JsonPropertyName("completion_tokens"), Required]
    public int? CompletionTokens { get; set; }

    /// <summary>
    /// Gets of sets total number of tokens used in the request (prompt + completion).
    /// </summary>
    [JsonPropertyName("total_tokens"), Required]
    public int? TotalTokens { get; set; }
}

/// <summary>
/// Content filtering results for a single prompt in the request.
/// </summary>
public class PromptFilterResult
{
    /// <summary>
    /// Gets or sets prompt index.
    /// </summary>
    [JsonPropertyName("prompt_index")]
    public int? PromptIndex { get; set; }

    /// <summary>
    /// Gets or sets information about the content filtering category (hate, sexual, violence, self_harm), 
    /// if it has been detected, as well as the severity level (very_low, low, medium, high-scale that determines the intensity and risk level of harmful content) and 
    /// if it has been filtered or not. Information about jailbreak content and profanity, 
    /// if it has been detected, and if it has been filtered or not. And information about customer block list, if it has been filtered and its id.
    /// </summary>
    [JsonPropertyName("content_filter_results")]
    public ContentFilterPromptResults? ContentFilterResults { get; set; }
}

/// <summary>
/// Represents a tool call generated by the model.
/// </summary>
public class ChatCompletionMessageToolCall
{
    /// <summary>
    /// Gets or sets the ID of the tool call.
    /// </summary>
    [JsonPropertyName("id"), Required]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the tool call, in this case `function`.
    /// </summary>
    [JsonPropertyName("type"), Required]
    public ToolCallType? Type { get; set; }

    /// <summary>
    /// Gets or sets the function that the model called.
    /// </summary>
    [JsonPropertyName("function"), Required]
    public FunctionObject? Function { get; set; }
}

/// <summary>
/// The function that the model called.
/// </summary>
public class FunctionObject
{
    /// <summary>
    /// Gets or sets the name of the function to call.
    /// </summary>
    [JsonPropertyName("name"), Required]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the arguments to call the function with, as generated by the model in JSON format. 
    /// Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.
    /// </summary>
    [JsonPropertyName("arguments"), Required]
    public string? Arguments { get; set; }
}

/// <summary>
/// Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model.
/// </summary>
public class ChatCompletionFunctionCall
{
    /// <summary>
    /// Gets or sets the name of the function to call.
    /// </summary>
    [JsonPropertyName("name"), Required]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the arguments to call the function with, as generated by the model in JSON format.
    /// Note that the model does not always generate valid JSON, and may hallucinate parameters not defined by your function schema. Validate the arguments in your code before calling your function.
    /// </summary>
    [JsonPropertyName("arguments"), Required]
    public string? Arguments { get; set; }
}

/// <summary>
/// A representation of the additional context information available when Azure OpenAI chat extensions are involved
/// in the generation of a corresponding chat completions response. This context information is only populated when
/// using an Azure OpenAI request configured to use a matching extension.
/// </summary>
public class AzureChatExtensionsMessageContext
{
    /// <summary>
    /// Gets or sets the data source retrieval result, used to generate the assistant message in the response.
    /// </summary>
    [JsonPropertyName("citations")]
    public List<Citation>? Citations { get; set; }

    /// <summary>
    /// Gets or sets the detected intent from the chat history, used to pass to the next turn to carry over the context.
    /// </summary>
    [JsonPropertyName("intent")]
    public string? Intent { get; set; }
}

/// <summary>
/// Content filtering results with citation information.
/// </summary>
public class ContentFilterDetectedWithCitationResult
{
    /// <summary>
    /// Gets or sets a value indicating whether the content was filtered.
    /// </summary>
    [JsonPropertyName("filtered"), Required]
    public bool? Filtered { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the content was detected.
    /// </summary>
    [JsonPropertyName("detected"), Required]
    public bool? Detected { get; set; }

    /// <summary>
    /// Gets or sets the citation details related to the content filtering result.
    /// </summary>
    [JsonPropertyName("citation")]
    public CitationObject? Citation { get; set; }
}

/// <summary>
/// Represents the citation details, including the URL and license information.
/// </summary>
public class CitationObject
{
    /// <summary>
    /// Gets or sets the URL of the citation.
    /// </summary>
    [JsonPropertyName("URL")]
    public string? URL { get; set; }

    /// <summary>
    /// Gets or sets the license information associated with the citation.
    /// </summary>
    [JsonPropertyName("license")]
    public string? License { get; set; }
}

/// <summary>
/// Token log probability information.
/// </summary>
public class ChatCompletionTokenLogProb
{
    /// <summary>
    /// Gets or sets the token.
    /// </summary>
    [JsonPropertyName("token"), Required]
    public string? Token { get; set; }

    /// <summary>
    /// Gets or sets the log probability of this token.
    /// </summary>
    [JsonPropertyName("logprob"), Required]
    public double? LogProb { get; set; }

    /// <summary>
    /// Gets or sets a list of integers representing the UTF-8 bytes representation of the token.
    /// </summary>
    [JsonPropertyName("bytes"), Required]
    public List<int>? Bytes { get; set; }

    /// <summary>
    /// Gets or sets list of the most likely tokens and their log probability, at this token position. 
    /// In rare cases, there may be fewer than the number of requested `top_logprobs` returned.
    /// </summary>
    [JsonPropertyName("top_logprobs"), Required]
    public List<TopLogProbs>? TopLogProbs { get; set; }
}

/// <summary>
/// List of the most likely tokens and their log probability, at this token position. 
/// In rare cases, there may be fewer than the number of requested `top_logprobs` returned.
/// </summary>
public class TopLogProbs
{
    /// <summary>
    /// Gets or sets the token.
    /// </summary>
    [JsonPropertyName("token"), Required]
    public string? Token { get; set; }

    /// <summary>
    /// Gets or sets the log probability of this token.
    /// </summary>
    [JsonPropertyName("logprob"), Required]
    public double? LogProb { get; set; }

    /// <summary>
    /// Gets or sets a list of integers representing the UTF-8 bytes representation of the token. 
    /// Useful in instances where characters are represented by multiple tokens and their byte representations must be combined to generate the correct text representation. 
    /// Can be `null` if there is no bytes representation for the token.
    /// </summary>
    [JsonPropertyName("bytes"), Required]
    public List<int>? Bytes { get; set; }
}

/// <summary>
/// Information about the content filtering category (hate, sexual, violence, self_harm), if it has been detected, 
/// as well as the severity level (very_low, low, medium, high-scale that determines the intensity and risk level of harmful content) 
/// and if it has been filtered or not. Information about jailbreak content and profanity, if it has been detected, 
/// and if it has been filtered or not. And information about customer block list, if it has been filtered and its id.
/// </summary>
public class ContentFilterPromptResults
{
    /// <summary>
    /// Gets or sets the severity result for sexual content.
    /// </summary>
    [JsonPropertyName("sexual")]
    public ContentFilterSeverityResult? Sexual { get; set; }

    /// <summary>
    /// Gets or sets the severity result for violent content.
    /// </summary>
    [JsonPropertyName("violence")]
    public ContentFilterSeverityResult? Violence { get; set; }

    /// <summary>
    /// Gets or sets the severity result for hateful content.
    /// </summary>
    [JsonPropertyName("hate")]
    public ContentFilterSeverityResult? Hate { get; set; }

    /// <summary>
    /// Gets or sets the severity result for self-harm content.
    /// </summary>
    [JsonPropertyName("self_harm")]
    public ContentFilterSeverityResult? SelfHarm { get; set; }

    /// <summary>
    /// Gets or sets the detected result for profane content.
    /// </summary>
    [JsonPropertyName("profanity")]
    public ContentFilterDetectedResult? Profanity { get; set; }

    /// <summary>
    /// Gets or sets error details for content filtering.
    /// </summary>
    [JsonPropertyName("error")]
    public ErrorBase? Error { get; set; }

    /// <summary>
    /// Gets or sets the detected result for jailbreak content.
    /// </summary>
    [JsonPropertyName("jailbreak")]
    public ContentFilterDetectedResult? Jailbreak { get; set; }
}

/// <summary>
/// Citation information for a chat completions response message.
/// </summary>
public class Citation
{
    /// <summary>
    /// Gets or sets the content of the citation.
    /// </summary>
    [JsonPropertyName("content"), Required]
    public string? Content { get; set; }

    /// <summary>
    /// Gets or sets the title of the citation.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the URL of the citation.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the file path of the citation.
    /// </summary>
    [JsonPropertyName("filepath")]
    public string? Filepath { get; set; }

    /// <summary>
    /// Gets or sets the chunk ID of the citation. 
    /// </summary>
    [JsonPropertyName("chunk_id")]
    public string? ChunkId { get; set; }
}

/// <summary>
/// Represents the result of content detection, indicating whether specific content was detected and whether it was filtered.
/// </summary>
public class ContentFilterDetectedResult
{
    /// <summary>
    /// Gets or sets a value indicating whether the content has been filtered.
    /// </summary>
    [JsonPropertyName("filtered"), Required]
    public bool? Filtered { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the content has been detected.
    /// </summary>
    [JsonPropertyName("detected"), Required]
    public bool? Detected { get; set; }
}

/// <summary>
/// Severity information for content filtering.
/// </summary>
public class ContentFilterSeverityResult
{
    /// <summary>
    /// Gets or sets a value indicating whether the content has been filtered.
    /// </summary>
    [JsonPropertyName("filtered"), Required]
    public bool? Filtered { get; set; }

    /// <summary>
    /// Gets or sets the severity level of the content.
    /// </summary>
    [JsonPropertyName("severity"), Required]
    public ContentFilterSeverity? Severity { get; set; }
}

/// <summary>
/// Error details for content filtering.
/// </summary>
public class ErrorBase
{
    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

/// <summary>
/// The type of the tool call, in this case `function`.
/// </summary>
[JsonConverter(typeof(EnumMemberConverter<ToolCallType>))]
public enum ToolCallType
{
    /// <summary>
    /// The tool call type is function.
    /// </summary>
    [EnumMember(Value = "function")]
    Function
}

/// <summary>
/// The role of the author of the response message.
/// </summary>
[JsonConverter(typeof(EnumMemberConverter<ChatCompletionResponseMessageRole>))]
public enum ChatCompletionResponseMessageRole
{
    /// <summary>
    /// The role of the assistant generating the response.
    /// </summary>
    [EnumMember(Value = "assistant")]
    Assistant
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(EnumMemberConverter<ChatCompletionResponseObject>))]
public enum ChatCompletionResponseObject
{
    /// <summary>
    /// The object type is chat completion.
    /// </summary>
    [EnumMember(Value = "chat.completion")]
    ChatCompletion
}

/// <summary>
/// Severity levels for content filtering.
/// </summary>
[JsonConverter(typeof(EnumMemberConverter<ContentFilterSeverity>))]
public enum ContentFilterSeverity
{
    /// <summary>
    /// General content or related content in generic or non-harmful contexts.
    /// </summary>
    [EnumMember(Value = "safe")]
    Safe,

    /// <summary>
    /// Harmful content at a low intensity and risk level.
    /// </summary>
    [EnumMember(Value = "low")]
    Low,

    /// <summary>
    /// Harmful content at a medium intensity and risk level.
    /// </summary>
    [EnumMember(Value = "medium")]
    Medium,

    /// <summary>
    /// Harmful content at a high intensity and risk level.
    /// </summary>
    [EnumMember(Value = "high")]
    High
}