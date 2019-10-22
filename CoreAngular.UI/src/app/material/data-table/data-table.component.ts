import { Component, OnInit, Input } from '@angular/core';
import { DataSource } from '@angular/cdk/table';
import { BehaviorSubject, Observable } from 'rxjs';
import { EntityService } from 'src/app/shared/services/entity.service';
import { Entity } from 'src/app/shared/models/entity';

export class AppDataSource extends DataSource<any[]> {
  constructor(private subject: BehaviorSubject<any[]>) {
    super ();
  }
  connect(): Observable<any[]> {
    return this.subject.asObservable();
  }
  disconnect(): void {}
}

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent<T extends Entity> implements OnInit {

  dataSource: AppDataSource;
  dataSubject = new BehaviorSubject<any[]>([]);
  @Input() path = '';
  @Input() displayedColumns: any[] = [];

  constructor(private apiService: EntityService<T>) { }

  ngOnInit() {
    this.dataSource = new AppDataSource(this.dataSubject);
    this.apiService.getAll()
    .subscribe({
      next: value => this.dataSubject.next([value])
    });
  }

}
