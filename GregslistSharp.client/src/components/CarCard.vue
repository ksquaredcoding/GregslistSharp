<template>
  <div class="card">
    <img class="rounded-top" :src="car?.imgUrl" :alt="car?.make">
    <div class="card-body d-flex justify-content-between align-items-center">
      <h5>{{ car?.make }} {{ car?.model }}</h5>
      <!-- <div class="align-items-center d-flex gap-2">
        <img :src="seller.picture" :alt="seller.name" :title="seller.name" height="30" class="rounded">
        <i class="mdi mdi-delete-forever fs-4 selectable rounded" @click.stop="$emit('deleteClassified')"
          v-if="account.id == seller.id"></i>
      </div> -->
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';

export default {
  props: {
    car: { type: Object, required: true },
    // seller: { type: SellerProfile, required: true }
  },
  setup(props, { emit }) {
    return {
      // account: computed(() => AppState.account),
      // deleteClassified() {
      //   emit('deleteClassified')
      // }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>
