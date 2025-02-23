import { Component, ElementRef, ViewChild, AfterViewChecked } from '@angular/core';
import { ChatService } from '../services/chat.service';
import {ChatMessageToDisplay} from "../models/models";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements AfterViewChecked {
  userMessage: string = '';
  messagesDisplay: ChatMessageToDisplay[] = [];
  stopPrintingAnswer: boolean = false;
  conversationId: string = '';

  @ViewChild('scrollContainer') private scrollContainer!: ElementRef;

  constructor(private chatService: ChatService) {
    this.conversationId = 'demo';
  }

  ngAfterViewChecked(): void {
    this.scrollToBottom();
  }

  sendMessage() {
    if (!this.userMessage.trim()) return;

    this.chatService.sendMessage(this.conversationId, this.userMessage)
      .subscribe(response => {

        const newDisplay: ChatMessageToDisplay = {
          ...response,
          botResponseDisplayedText: ''
        };
        this.messagesDisplay.push(newDisplay);

        // Simulate type writing
        this.simulateTyping(newDisplay);

        this.userMessage = '';
      });
  }

  rateAnswer(messageId: number, rating: number) {
    this.chatService.rateAnswer(messageId, rating).subscribe(()=> {
      this.chatService.getChatHistory(this.conversationId).subscribe(messages => {
        this.messagesDisplay = messages.map(m => ({...m, botResponseDisplayedText: m.botResponse}));
      })
    });
  }

  onStopPrintAnswer(message: ChatMessageToDisplay) {
   this.stopPrintingAnswer = true;

    this.chatService.savePartialAnswer(message.id, message.botResponseDisplayedText).subscribe(() => {
      this.stopPrintingAnswer = false;
    });
  }

  private simulateTyping(message: ChatMessageToDisplay) {
    let index = 0;
    const typeCharacter = () => { // If the flag is set, exit early.
      if (this.stopPrintingAnswer) {
        return;
      }
      if (index < message.botResponse.length) {
        message.botResponseDisplayedText += message.botResponse.charAt(index);
        index++;
        const randomDelay = Math.floor(Math.random());
        setTimeout(typeCharacter, randomDelay);
      }
    };
    typeCharacter();
  }

  private scrollToBottom(): void {
    try {
      this.scrollContainer.nativeElement.scrollTop = this.scrollContainer.nativeElement.scrollHeight;
    } catch (err) {
      console.error('Error scrolling to bottom', err);
    }
  }
}
