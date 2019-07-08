import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RoomService {

  constructor(private http: HttpClient) { }

  save(room) {
    return this.http.post('/api/rooms', room);
  }

  getRooms(query) {
    return this.http.get('/api/rooms?' + this.toQueryString(query));
  }

  delete(id: any) {
    return this.http.delete('/api/rooms/' + id);
  }

  getRoom(id: string) {
    return this.http.get('/api/rooms/' + id);
  }

  update(room: SaveRoom) {
    return this.http.put('/api/rooms/' + room.id, room);
  }

  toQueryString(obj) {
    const parts = [];
    for (const key of Object.keys(obj)) {
      const value = obj[key];
      if (value !== null && value !== undefined) {
        parts.push(encodeURIComponent(key) + '=' + encodeURIComponent(value));
      }
    }

    return parts.join('&');
  }
}
