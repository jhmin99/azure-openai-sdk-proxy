using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using AzureOpenAIProxy.ApiApp.Converters;

namespace AzureOpenAIProxy.ApiApp.Models;

/// <summary>
/// The response from creating a chat completion.
/// For more information, see <a href="https://github.com/Azure/azure-rest-api-specs/blob/main/specification/cognitiveservices/data-plane/AzureOpenAI/inference/stable/2024-06-01/inference.json">azure-rest-api-specs(2024-06-01)</a>
/// </summary>
public class CreateChatCompletionResponse
{
    [JsonPropertyName("id"), Required]
    public string? Id { get; set; }

    [JsonPropertyName("object"), Required]
    public ChatCompletionResponseObject? Object { get; set; }

    [JsonPropertyName("created"), Required]
    public long? Created { get; set; }

    [JsonPropertyName("model"), Required]
    public string? Model { get; set; }

    [JsonPropertyName("usage")]
    public CompletionUsage? Usage { get; set; }

    [JsonPropertyName("system_fingerprint")]
    public string? SystemFingerprint { get; set; }

    [JsonPropertyName("prompt_filter_results")]
    public List<PromptFilterResult>? PromptFilterResults { get; set; }

    [JsonPropertyName("choices"), Required]
    public List<ChatCompletionChoice>? Choices { get; set; }
}

/// <summary>
/// Represents a choice in the chat completion response.
/// </summary>
public class ChatCompletionChoice
{
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }

    [JsonPropertyName("message")]
    public ChatCompletionResponseMessage? Message { get; set; }

    [JsonPropertyName("content_filter_results")]
    public ContentFilterChoiceResults? ContentFilterResults { get; set; }

    [JsonPropertyName("logprobs")]
    public ChatCompletionChoiceLogProbs? LogProbs { get; set; }
}

/// <summary>
/// A chat completion message generated by the model.
/// </summary>
public class ChatCompletionResponseMessage
{
    [JsonPropertyName("role")]
    public ChatCompletionResponseMessageRole? Role { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("tool_calls")]
    public List<ChatCompletionMessageToolCall>? ToolCalls { get; set; }

    [JsonPropertyName("function_call")]
    public ChatCompletionFunctionCall? FunctionCall { get; set; }

    [JsonPropertyName("context")]
    public AzureChatExtensionsMessageContext? Context { get; set; }
}

/// <summary>
/// Information about the content filtering category (hate, sexual, violence, self_harm), 
/// if it has been detected, as well as the severity level (very_low, low, medium, high-scale that determines the intensity and risk level of harmful content) 
/// and if it has been filtered or not.
/// </summary>
public class ContentFilterChoiceResults
{
    [JsonPropertyName("sexual")]
    public ContentFilterSeverityResult? Sexual { get; set; }

    [JsonPropertyName("violence")]
    public ContentFilterSeverityResult? Violence { get; set; }

    [JsonPropertyName("hate")]
    public ContentFilterSeverityResult? Hate { get; set; }

    [JsonPropertyName("self_harm")]
    public ContentFilterSeverityResult? SelfHarm { get; set; }

    [JsonPropertyName("profanity")]
    public ContentFilterDetectedResult? Profanity { get; set; }

    [JsonPropertyName("error")]
    public ErrorBase? Error { get; set; }

    [JsonPropertyName("protected_material_text")]
    public ContentFilterDetectedResult? ProtectedMaterialText { get; set; }

    [JsonPropertyName("protected_material_code")]
    public ContentFilterDetectedWithCitationResult? ProtectedMaterialCode { get; set; }
}

/// <summary>
/// Log probability information for the choice.
/// </summary>
public class ChatCompletionChoiceLogProbs
{
    [JsonPropertyName("content"), Required]
    public List<ChatCompletionTokenLogProb>? Content { get; set; }
}

/// <summary>
/// Usage statistics for the completion request.
/// </summary>
public class CompletionUsage
{
    [JsonPropertyName("prompt_tokens"), Required]
    public int? PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens"), Required]
    public int? CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens"), Required]
    public int? TotalTokens { get; set; }
}

/// <summary>
/// Content filtering results for a single prompt in the request.
/// </summary>
public class PromptFilterResult
{
    [JsonPropertyName("prompt_index")]
    public int? PromptIndex { get; set; }

    [JsonPropertyName("content_filter_results")]
    public ContentFilterPromptResults? ContentFilterResults { get; set; }
}

/// <summary>
/// Represents a tool call generated by the model.
/// </summary>
public class ChatCompletionMessageToolCall
{
    [JsonPropertyName("id"), Required]
    public string? Id { get; set; }

    [JsonPropertyName("type"), Required]
    public ToolCallType? Type { get; set; }

    [JsonPropertyName("function"), Required]
    public FunctionObject? Function { get; set; }
}

/// <summary>
/// The function that the model called.
/// </summary>
public class FunctionObject
{
    [JsonPropertyName("name"), Required]
    public string? Name { get; set; }

    [JsonPropertyName("arguments"), Required]
    public string? Arguments { get; set; }
}

/// <summary>
/// Deprecated and replaced by `tool_calls`. 
/// The name and arguments of a function that should be called, as generated by the model.
/// </summary>
public class ChatCompletionFunctionCall
{
    [JsonPropertyName("name"), Required]
    public string? Name { get; set; }

    [JsonPropertyName("arguments"), Required]
    public string? Arguments { get; set; }
}

/// <summary>
/// A representation of the additional context information available when Azure OpenAI chat extensions are involved
/// in the generation of a corresponding chat completions response.
/// </summary>
public class AzureChatExtensionsMessageContext
{
    [JsonPropertyName("citations")]
    public List<Citation>? Citations { get; set; }

    [JsonPropertyName("intent")]
    public string? Intent { get; set; }
}

/// <summary>
/// Content filtering results with citation information.
/// </summary>
public class ContentFilterDetectedWithCitationResult
{
    [JsonPropertyName("filtered"), Required]
    public bool? Filtered { get; set; }

    [JsonPropertyName("detected"), Required]
    public bool? Detected { get; set; }

    [JsonPropertyName("citation")]
    public CitationObject? Citation { get; set; }
}

/// <summary>
/// Citation object within a content filtering result.
/// </summary>
public class CitationObject
{
    [JsonPropertyName("URL")]
    public string? URL { get; set; }

    [JsonPropertyName("license")]
    public string? License { get; set; }
}

/// <summary>
/// Token log probability information.
/// </summary>
public class ChatCompletionTokenLogProb
{
    [JsonPropertyName("token"), Required]
    public string? Token { get; set; }

    [JsonPropertyName("logprob"), Required]
    public double? LogProb { get; set; }

    [JsonPropertyName("bytes"), Required]
    public List<int>? Bytes { get; set; }

    [JsonPropertyName("top_logprobs"), Required]
    public List<TopLogProbs>? TopLogProbs { get; set; }
}

/// <summary>
/// List of the most likely tokens and their log probability, at this token position. 
/// In rare cases, there may be fewer than the number of requested `top_logprobs` returned.
/// </summary>
public class TopLogProbs
{
    [JsonPropertyName("token"), Required]
    public string? Token { get; set; }

    [JsonPropertyName("logprob"), Required]
    public double? LogProb { get; set; }

    [JsonPropertyName("bytes"), Required]
    public List<int>? Bytes { get; set; }
}

/// <summary>
/// Information about the content filtering category (hate, sexual, violence, self_harm), 
/// if it has been detected, as well as the severity level (very_low, low, medium, high-scale that determines the intensity and risk level of harmful content)
/// and if it has been filtered or not. Information about jailbreak content and profanity, if it has been detected, and if it has been filtered or not. 
/// And information about customer block list, if it has been filtered and its id.
/// </summary>
public class ContentFilterPromptResults
{
    [JsonPropertyName("sexual")]
    public ContentFilterSeverityResult? Sexual { get; set; }

    [JsonPropertyName("violence")]
    public ContentFilterSeverityResult? Violence { get; set; }

    [JsonPropertyName("hate")]
    public ContentFilterSeverityResult? Hate { get; set; }

    [JsonPropertyName("self_harm")]
    public ContentFilterSeverityResult? SelfHarm { get; set; }

    [JsonPropertyName("profanity")]
    public ContentFilterDetectedResult? Profanity { get; set; }

    [JsonPropertyName("error")]
    public ErrorBase? Error { get; set; }

    [JsonPropertyName("jailbreak")]
    public ContentFilterDetectedResult? Jailbreak { get; set; }
}

/// <summary>
/// Citation information for a chat completions response message.
/// </summary>
public class Citation
{
    [JsonPropertyName("content"), Required]
    public string? Content { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("filepath")]
    public string? Filepath { get; set; }

    [JsonPropertyName("chunk_id")]
    public string? ChunkId { get; set; }
}

/// <summary>
/// Content filtering result details.
/// </summary>
public class ContentFilterDetectedResult
{
    [JsonPropertyName("filtered"), Required]
    public bool? Filtered { get; set; }

    [JsonPropertyName("detected"), Required]
    public bool? Detected { get; set; }
}

/// <summary>
/// Severity information for content filtering.
/// </summary>
public class ContentFilterSeverityResult
{
    [JsonPropertyName("filtered"), Required]
    public bool? Filtered { get; set; }

    [JsonPropertyName("severity"), Required]
    public ContentFilterSeverity? Severity { get; set; }
}

/// <summary>
/// Error details for content filtering.
/// </summary>
public class ErrorBase
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

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
