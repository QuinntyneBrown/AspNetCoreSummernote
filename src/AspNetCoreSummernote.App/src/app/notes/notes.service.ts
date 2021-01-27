import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Note } from './note';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  public get(): Observable<Note[]> {
    return this._client.get<{ notes: Note[] }>(`${this._baseUrl}api/notes`)
      .pipe(
        map(x => x.notes)
      );
  }

  public getById(options: { noteId: number }): Observable<Note> {
    return this._client.get<{ note: Note }>(`${this._baseUrl}api/notes/${options.noteId}`)
      .pipe(
        map(x => x.note)
      );
  }

  public remove(options: { note: Note }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/notes/${options.note.noteId}`);
  }

  public save(options: { note: Note }): Observable<{ noteId: number }> {
    return this._client.post<{ noteId: number }>(`${this._baseUrl}api/notes`, { note: options.note });
  }  
}
