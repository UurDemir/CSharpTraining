import { BasketProduct } from './basketProduct';
import { User } from './user';

export interface Order {
  user: User;
  basketProduces: BasketProduct[];
  date: Date;
}
