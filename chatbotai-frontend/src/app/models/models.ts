interface ChatMessage {
  id: number;
  userMessage: string;
  botResponse: string;
  conversationId: string;
  rating?: number;
}

interface ChatMessageToDisplay {
  id: number;
  userMessage: string;
  botResponse: string;
  botResponseDisplayedText: string;
  conversationId: string;
  rating?: number;
}

export { ChatMessage, ChatMessageToDisplay };
