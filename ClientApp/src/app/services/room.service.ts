import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RoomService {

  constructor(private http: HttpClient) { }

  save(room) {
    return this.http.post('/api/rooms', room);
  }

  getRooms() {
    return this.http.get('/api/rooms');
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
}
