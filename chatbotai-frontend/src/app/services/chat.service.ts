import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface ChatMessage {
  id: number;
  userMessage: string;
  botResponse: string;
  conversationId: string;
  rating?: number;
}

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private apiUrl = 'http://localhost:5159/api/chat';

  constructor(private http: HttpClient) {}

  sendMessage(conversationId: string, userMessage: string): Observable<ChatMessage> {
    return this.http.post<ChatMessage>(`${this.apiUrl}/send-message`, { conversationId,userMessage});
  }

  getChatHistory(conversationId: string): Observable<ChatMessage[]> {
    return this.http.get<ChatMessage[]>(`${this.apiUrl}/history/${conversationId}`);
  }

  rateAnswer(messageId: number, rating: number): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/rate-answer`, { messageId, rating });
  }

  savePartialAnswer(messageId: number, botPartialAnswer: string): Observable<boolean> {
    return this.http.post<boolean>(`${this.apiUrl}/save-partial-answer`, { messageId, botPartialAnswer });
  }
}
